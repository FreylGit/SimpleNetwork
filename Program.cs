var neuron = new Neuron(Activation.Threshold);
double[] input1 = new double[] { 1.0, 1.0 };//Первая строчка таблицы
double[] input2 = new double[] { 1.0, 0.0 };//Вторая строчка таблицы
double[] input3 = new double[] { 0.0, 1.0 };//Третья строчка таблицы
double[] input4 = new double[] { 0.0, 0.0 };//Четвертая строчка таблицы

int i = 0;
do
{
    i++;
    neuron.Learn(input1, 1.0);
    neuron.Learn(input2, 0.0);
    neuron.Learn(input3, 1.0);
    neuron.Learn(input4, 0);

    neuron.Learn(input2, 0.0);
    neuron.Learn(input3, 1.0);
    neuron.Learn(input4, 0);
    neuron.Learn(input1, 1.0);

    neuron.Learn(input3, 1.0);
    neuron.Learn(input4, 0);
    neuron.Learn(input1, 1.0);
    neuron.Learn(input2, 0.0);

    neuron.Learn(input4, 0);
    neuron.Learn(input1, 1.0);
    neuron.Learn(input2, 0.0);
    neuron.Learn(input3, 1.0);
    //По очереди меняем порядок обучения чтобы было все четко, может не правильно, но работает 
}
while (neuron.LastError > neuron.Smoothing || neuron.LastError < -neuron.Smoothing);

Console.WriteLine(neuron.weigth[0] + " " + neuron.weigth[1]);
Console.WriteLine(neuron.InputData(input1));
Console.WriteLine(neuron.InputData(input2));
Console.WriteLine(neuron.InputData(input3));
Console.WriteLine(neuron.InputData(input4));

