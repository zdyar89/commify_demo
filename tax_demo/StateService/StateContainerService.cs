namespace tax_demo.StateService
{
    public class StateContainerService
    {
        // State property with initial value
        public double Value { get; set; } = 0;

        // Event to be raised for state change
        
        public event Action OnStateChange;


        // Method to be used by sender component to update state
        public void SetValue(double? value)
        {
            Value = value ?? 0.0;
            NotifyStateChanged();
        }

        // State change event notification
        private void NotifyStateChanged() => OnStateChange?.Invoke();
    }
}
