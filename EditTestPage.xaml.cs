using System.Windows.Controls;
using System.Windows.Input;

namespace generator
{
    public partial class EditTestPage
    {
        private Test? _lastTest;

        public EditTestPage()
        {
            InitializeComponent();
            var test = Serializer.Deserialize();
            if (test == null || test.Count == 0) AddTest(test);
            TestGrid.ItemsSource = test;
        }

        private void TestGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            if (_lastTest == null && string.IsNullOrWhiteSpace(_lastTest?.Name) && 
                string.IsNullOrWhiteSpace(_lastTest?.Description) && 
                string.IsNullOrWhiteSpace(_lastTest?.FirstAnswer) &&
                string.IsNullOrWhiteSpace(_lastTest?.SecondAnswer) && 
                string.IsNullOrWhiteSpace(_lastTest?.ThirdAnswer)) 
                AddTest(TestGrid.ItemsSource as ICollection<Test>);
        }

        private void AddTest(ICollection<Test>? test)
        {
            test?.Add(new Test(name: "", description: "", firstAnswer: "", secondAnswer: "", thirdAnswer: "", 
                rightAnswer: RightAnswer.FirstAnswer, test: new List<Test>()));
            Serializer.Serialize(test);
            _lastTest = test?.LastOrDefault();
        }

        private void TestGrid_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Delete) return;
            if (TestGrid.ItemsSource is not List<Test> test || TestGrid.SelectedItem == null) return;
            var testToRemove = (Test)TestGrid.SelectedItem;
            test.Remove(testToRemove);
            Serializer.Serialize(test);
            TestGrid.ItemsSource = test;
        }
    }
}