using System.ComponentModel;

namespace HandyTool.HandyTool.Infrastructure
{
    public class SortableBindingList<T> : BindingList<T>
    {
        private bool isSorted;
        private ListSortDirection sortDirection;
        private PropertyDescriptor sortProperty;

        public SortableBindingList(IList<T> list) : base(list) { }

        protected override bool SupportsSortingCore => true;
        protected override bool IsSortedCore => isSorted;

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            var itemsList = (List<T>)Items;
            var sortedList = direction == ListSortDirection.Ascending
                ? itemsList.OrderBy(x => prop.GetValue(x)).ToList()
                : itemsList.OrderByDescending(x => prop.GetValue(x)).ToList();

            itemsList.Clear();
            foreach (var item in sortedList)
                itemsList.Add(item);

            sortProperty = prop;
            sortDirection = direction;
            isSorted = true;

            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void RemoveSortCore()
        {
            isSorted = false;
        }

        protected override PropertyDescriptor SortPropertyCore => sortProperty;
        protected override ListSortDirection SortDirectionCore => sortDirection;
    }
}
