namespace Pulinho
{
    public delegate void CallBack();

    public class Player : Animacao
    {
        public Player(CachedImage a) : base(a)
        {
            // Animação do Goku voando
            for (int i = 1; i <= 4; i++)
            {
                animacao1.Add($"goku{i.ToString("D2")}.png");
            }
            // Animação de "morte"
            for (int i = 1; i < 6; i++)
            {
                animacao2.Add($"morreu{i.ToString("D2")}.png");
            }

            // Define a animação inicial como voando
            SetAnimacaoAtiva(1);
            Play();
        }

        public void Die()
        {
            loop = false;
            SetAnimacaoAtiva(2);
        }

        public void Run()
        {
            loop = true;
            SetAnimacaoAtiva(1);
            Play();
        }
    }
}
