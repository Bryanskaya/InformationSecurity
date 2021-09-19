namespace lab02
{
    class Rotor : Device
    {
        public int move()
        {
            int temp = connectionsArr[0];
            for (int i = 0; i < num; i++)
                connectionsArr[i] = connectionsArr[(i + 1) % num];
            connectionsArr[num - 1] = temp;

            amountRot++;
            amountRot %= num;

            return amountRot;
        }
    }
}
