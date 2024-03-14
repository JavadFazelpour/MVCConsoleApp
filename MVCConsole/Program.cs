namespace MVCConsole
{
   // https://stackoverflow.com/questions/1108247/mvc-like-design-for-console-applications
    public interface IController
    {
        void RequestView(IView view);
        IView ResponseView();
    }
    public interface IView
    {
        int GetID { set; get; }
        void DisplayId();
    }
    public interface IModel
    {
        int GenrateID(int id);
    }
    //Business logic in Model
    public class Model : IModel
    {
        public int GenrateID(int id)
        {
            id = id * 10;
            return id;
        }
    }
    //Event Logic in Controller
    public class Controller : IController
    {
        private IModel model;
        private IView responseView;
        public Controller()
        {
            responseView = new View();
        }
        public void RequestView(IView view)
        {
            model = new Model();
            responseView.GetID = model.GenrateID(view.GetID);
        }
        public IView ResponseView()
        {
            return responseView;
        }
    }
    //Display Logic in View
    public class View : IView
    {
        public int GetID
        {
            get; set;
        }
        public void DisplayId()
        {
            Console.Write(GetID);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IController ctr = new Controller();
            int input = 50;//user input
            IView view = new View()
            {
                GetID = input
            };

            ctr.RequestView(view);
            view = ctr.ResponseView();
            view.DisplayId();
        }
    }
}
