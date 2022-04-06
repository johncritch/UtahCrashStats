using System;
namespace UtahCrashStats.Models
{
    public class LayoutModel
    {
        public LayoutModel(string title)
        {
            Title = title;
        }

        public string Title { get; }
    }

    public class LayoutModel<T> : LayoutModel
    {
        public LayoutModel(T pageModel, string title) : base(title)
        {
            PageModel = pageModel;
        }

        public T PageModel { get; }
    }
}
