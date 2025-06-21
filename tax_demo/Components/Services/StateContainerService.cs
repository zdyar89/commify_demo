namespace tax_demo.Components.Services
{
    // Service to handle state container data
    public class StateContainerService
    {
        // State property with initial value
        public double Value { get; set; } = 0;

        // Event to be raised for state change
        public event Action OnStateChange;


        // Method to be used by sender component to update state
        public void SetValue(double value)
        {
            Value = value;
            NotifyStateChanged();
        }

        // State change event notification
        private void NotifyStateChanged()=>OnStateChange?.Invoke();
    }
}
