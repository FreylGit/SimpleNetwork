
//Тип функции активации
public enum Activation
{
    Threshold = 0,
    Sigmoid = 1,
}
public class Neuron
{
    public double LastError { get; set; }
    public double Smoothing { get; set; } = 0.00001;
    public double[] weigth { get; set; }
    private Activation Activation { get; set; }

    public Neuron(Activation activation = Activation.Threshold)
    {
        Random random = new Random();
        weigth = new double[2];
        weigth[0] = random.NextDouble();
        weigth[1] = random.NextDouble();
        Activation = activation;
    }
    public double InputData(double[] input)
    {
        var sum = 0.0;
        for (int i = 0; i < weigth.Length; i++)
        {
            sum += weigth[i] * input[i];
        }
        if (Activation == Activation.Sigmoid)
        {
            return Sigmoid(sum);
        }
        if (Activation == Activation.Threshold)
        {
            return Threshold(sum);
        }
        return sum;
    }

    //Функция обучения неирона
    public void Learn(double[] input, double expectedResult)
    {
        var actualResult = 0.0;
        for (int i = 0; i < weigth.Length; i++)
        {
            actualResult += weigth[i] * input[i];
        }
        if(Activation == Activation.Sigmoid)
        {
            actualResult = Sigmoid(actualResult);
        }
        if(Activation == Activation.Threshold)
        {
            actualResult = Threshold(actualResult);
        }
        LastError = expectedResult - actualResult;

        if (actualResult == 0.0)
        {
            actualResult = 0.00001;
        }
        var correction = (LastError / actualResult) * Smoothing;
        for (int i = 0; i < weigth.Length; i++)
        {
            weigth[i] += correction;
        }
    }
    //Сигмоидная функция
    private double Sigmoid(double x)
    {
        return (1 / (1 + Math.Exp(-x)));
    }
    //Пороговая функция
    private double Threshold(double x)
    {
        if (x >= 0.5)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}