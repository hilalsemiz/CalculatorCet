namespace CalculatorCet
{
    public partial class MainPage : ContentPage
    {



        public MainPage()
        {
            InitializeComponent();
        }


        double FirstNumber;
        bool isFirstNumberAfterOperator = true;
        Operator PreviousOperator = Operator.None;
        double MemoryNumber = 0;


        private void SubtractButton_Clicked(object sender, EventArgs e)
        {
            DoCalculation();
            PreviousOperator = Operator.Subtract;

        }

        private void MultiplyButton_Clicked(object sender, EventArgs e)
        {
            DoCalculation();
            PreviousOperator = Operator.Multiply;
        }

        private void DivideButton_Clicked(object sender, EventArgs e)
        {
            DoCalculation();
            PreviousOperator = Operator.Divide;

        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {

            DoCalculation();
            PreviousOperator = Operator.Add;

        }
void DoCalculation()
{
    if (!string.IsNullOrEmpty(Display.Text)) 
    {
        double currentNumber = Double.Parse(Display.Text);

        
        switch (PreviousOperator)
        {
            case Operator.None:
                FirstNumber = currentNumber;
                break;
            case Operator.Add:
                FirstNumber += currentNumber;
                break;
            case Operator.Subtract:
                FirstNumber -= currentNumber;
                break;
            case Operator.Multiply:
                FirstNumber *= currentNumber;
                break;
            case Operator.Divide:
                FirstNumber /= currentNumber;
                break;
        }

        
        Display.Text = FirstNumber.ToString();
    }

    
    isFirstNumberAfterOperator = true; 
    PreviousOperator = Operator.None; 
}


        private void Digit_Clicked(object sender, EventArgs e)
        {
            Button digitButton = sender as Button;
            if(isFirstNumberAfterOperator)
            {
                Display.Text = digitButton.Text=="," ? "0," : digitButton.Text;
                isFirstNumberAfterOperator = false;

            }
            else
            {
                if(digitButton.Text=="," && Dispaly.Text.Contains(","))
                  return;
                Display.Text += digitButton.Text;
            }
           
        }

        private void EqualButton_Clicked(object sender, EventArgs e)
        {
            DoCalculation();
            PreviousOperator = Operator.None;

        }

        private void CEButton_Clicked(object sender, EventArgs e)
        {
            Display.Text = "0";
            isFirstNumberAfterOperator = true;
        }

        private void CButton_Clicked(object sender, EventArgs e)
        {
            Display.Text = "0";
            FirstNumber = 0;
            PreviousOperator= Operator.None;
            isFirstNumberAfterOperator = true;
        }
        private void MSButton_Clicked(object sender, EventArgs e)
        {
        MemoryNumber = Double.Parse(Display.Text);
        }
        private void MRbutton_Clicked(object sender,EventArgs e)
        {
        Display.Text = MemoryNumber.ToString();
        isFirstNumberAfterOperator = true;
        }
    }

}
