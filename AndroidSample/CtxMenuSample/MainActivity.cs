using Android.App;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using static Android.Widget.AbsListView;
using static Android.Widget.AdapterView;

namespace CtxMenuSample
{
  [Activity(Label = "@string/app_name", Theme = "@android:style/Theme.Holo.Light.DarkActionBar", MainLauncher = true)]
  public class MainActivity : ListActivity, IOnItemLongClickListener, ActionMode.ICallback, IMultiChoiceModeListener
  {
    private const string SINGLE_SELECT = "SINGLE_SELECT";
    private const string MULTI_SELECT = "MULTI_SELECT";

    private static readonly string STATE_CHOICE_MODE = "choiceMode";
    private static readonly string STATE_MODEL = "model";
    private static readonly string[] items = { "lorem", "ipsum", "dolor",
      "sit", "amet", "consectetuer", "adipiscing", "elit", "morbi",
      "vel", "ligula", "vitae", "arcu", "aliquet", "mollis", "etiam",
      "vel", "erat", "placerat", "ante", "porttitor", "sodales",
      "pellentesque", "augue", "purus" };

    private IList<string> words = null;
    private ArrayAdapter<string> adapter = null;
    private ActionMode activeMode = null;

    private string behavior = MULTI_SELECT;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      if (savedInstanceState == null)
      {
        InitAdapter(null);
      }
      else
      {
        InitAdapter(savedInstanceState.GetStringArrayList(STATE_MODEL));
      }

      this.ListView.OnItemLongClickListener = this;
      this.ListView.SetMultiChoiceModeListener(this);

      var choiceMode = (ChoiceMode)(savedInstanceState == null ? (int)ChoiceMode.None : savedInstanceState.GetInt(STATE_CHOICE_MODE));

      this.ListView.ChoiceMode = ChoiceMode.None;
    }

    protected override void OnListItemClick(ListView l, View v, int position, long id)
    {
      l.SetItemChecked(position, true);
    }

    public override bool OnCreateOptionsMenu(IMenu menu)
    {
      this.MenuInflater.Inflate(Resource.Menu.actions, menu);

      return base.OnCreateOptionsMenu(menu);
    }

    public override void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
    {
      this.MenuInflater.Inflate(Resource.Menu.context, menu);
    }

    public override bool OnOptionsItemSelected(IMenuItem item)
    {
      switch (item.ItemId)
      {
        case Resource.Id.single:
          this.behavior = SINGLE_SELECT;

          Toast.MakeText(this, "ActionMode behaves like a single select", ToastLength.Long).Show();

          return (true);

        case Resource.Id.multi:
          this.behavior = MULTI_SELECT;

          Toast.MakeText(this, "ActionMode behaves like a multi select", ToastLength.Long).Show();

          return (true);
      }

      return base.OnOptionsItemSelected(item);
    }


    public bool OnItemLongClick(AdapterView parent, View view, int position, long id)
    {
      this.ListView.ChoiceMode = ChoiceMode.MultipleModal;
      this.ListView.SetItemChecked(position, true);

      return (true);
    }

    protected override void OnSaveInstanceState(Bundle state)
    {
      base.OnSaveInstanceState(state);

      state.PutInt(STATE_CHOICE_MODE, (int)this.ListView.ChoiceMode);
      state.PutStringArrayList(STATE_MODEL, this.words);
    }


    private void UpdateSubtitle(ActionMode mode)
    {
      mode.Subtitle = $"({this.ListView.CheckedItemCount})";
    }

    public bool PerformActions(IMenuItem item)
    {
      var adapter = (ArrayAdapter<string>)this.ListAdapter;
      SparseBooleanArray pchecked = this.ListView.CheckedItemPositions;

      switch (item.ItemId)
      {
        case Resource.Id.cap:
          for (var i = 0; i < pchecked.Size(); i++)
          {
            if (pchecked.ValueAt(i))
            {
              var position = pchecked.KeyAt(i);
              var word = this.words[position];

              word = word.ToUpper();

              adapter.Remove(this.words[position]);
              adapter.Insert(word, position);
            }
          }

          return (true);

        case Resource.Id.remove:
          var positions = new List<int>();

          for (var i = 0; i < pchecked.Size(); i++)
          {
            if (pchecked.ValueAt(i))
            {
              positions.Add(pchecked.KeyAt(i));
            }
          }

          positions.Reverse();

          foreach (var position in positions)
          {
            adapter.Remove(this.words[position]);
          }

          this.ListView.ClearChoices();

          return (true);
      }

      return (false);
    }


    private void InitAdapter(IList<string> startingPoint)
    {
      if (startingPoint == null)
      {
        this.words = new List<string>();

        for (var i = 0; i < 5; i++)
        {
          this.words.Add(items[i]);
        }
      }
      else
      {
        this.words = startingPoint;
      }

      this.adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItemActivated1, this.words);
      this.ListAdapter = this.adapter;
    }

    private void AddWord()
    {
      if (this.adapter.Count < items.Length)
      {
        this.adapter.Add(items[this.adapter.Count]);
      }
    }

    public bool OnActionItemClicked(ActionMode mode, IMenuItem item)
    {
      var result = PerformActions(item);

      UpdateSubtitle(this.activeMode);

      return (result);
    }

    public bool OnCreateActionMode(ActionMode mode, IMenu menu)
    {
      this.MenuInflater.Inflate(Resource.Menu.context, menu);
      mode.Title = GetString(Resource.String.context_title);

      this.activeMode = mode;
      UpdateSubtitle(this.activeMode);

      return (true);
    }

    public void OnDestroyActionMode(ActionMode mode)
    {
      if (this.activeMode != null)
      {
        this.activeMode = null;
        this.ListView.ChoiceMode = ChoiceMode.None;
        this.ListView.Adapter = this.ListView.Adapter;
      }
    }

    public bool OnPrepareActionMode(ActionMode mode, IMenu menu)
    {
      return false;
    }

    public void OnItemCheckedStateChanged(ActionMode mode, int position, long id, bool @checked)
    {
      if (this.activeMode != null)
      {
        if (this.behavior == SINGLE_SELECT && this.ListView.CheckedItemCount > 1)
        {

          SparseBooleanArray checkarr = this.ListView.CheckedItemPositions;
          for (var i = 0; i < this.ListView.Adapter.Count; i++)
          {
            /*
            check item is checked
            and not the last item
            */
            if (checkarr.Get(i) && position != i)
            {
              this.ListView.SetItemChecked(i, false);
              break;
            }
          }
        }

        UpdateSubtitle(mode);
      }
    }
  }
}

