
namespace Pulinho
{
    public partial class MainPage
    {
        private bool estaMorto = false;
        private const int TempoEntreFrames = 15;

        private int velocidade;
        private int velocidade1;
        private int velocidade2;
        private int velocidade3;
        private int velocidade4;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _ = Desenha();
        }

        private async Task Desenha()
        {
            while (!estaMorto)
            {
                GerenciaCenarios();
                player.Desenha();
                await Task.Delay(TempoEntreFrames);
            }
        }

        protected override void OnSizeAllocated(double largura, double altura)
        {
            base.OnSizeAllocated(largura, altura);
            CorrigeTamanhoCenario(largura);
            CalculaVelocidade(largura);
        }

        private void CalculaVelocidade(double largura)
        {
            velocidade1 = (int)(largura * 1);
            velocidade2 = (int)(largura * 2);
            velocidade3 = (int)(largura * 3);
            velocidade4 = (int)(largura * 5);
            velocidade = (int)(largura *  6);
        }

        private void CorrigeTamanhoCenario(double largura)
        {
            AjustaLarguraImagens(HsOne, largura);
            AjustaLarguraImagens(HsTwo, largura);
            AjustaLarguraImagens(HsThree, largura);
            AjustaLarguraImagens(Hsfour, largura);
            AjustaLarguraImagens(HsDoGoku, largura);

            HsOne.WidthRequest = largura * 1.5;
            HsTwo.WidthRequest = largura * 1.5;
            HsThree.WidthRequest = largura * 1.5;
            Hsfour.WidthRequest = largura * 1.5;
            HsDoGoku.WidthRequest = largura * 1.5;
            
        }

        private void AjustaLarguraImagens(HorizontalStackLayout stackLayout, double largura)
        {
            foreach (var elemento in stackLayout.Children)
            {
                if (elemento is Image imagem)
                {
                    imagem.WidthRequest = largura;
                }
            }
        }

        private void GerenciaCenarios()
        {
            MoveCenario();
            GerenciaCenario(HsOne);
            GerenciaCenario(HsTwo);
            GerenciaCenario(HsThree);
            GerenciaCenario(Hsfour);
            GerenciaCenario(HsDoGoku);
           
        }

        private void MoveCenario()
        {
            HsOne.TranslationX -= velocidade1;
            HsTwo.TranslationX -= velocidade2;
            HsThree.TranslationX -= velocidade3;
            Hsfour.TranslationX -= velocidade4;
            HsDoGoku.TranslationX -= velocidade3;
            
        }

        private void GerenciaCenario(HorizontalStackLayout stackLayout)
        {
            if (stackLayout.Children.FirstOrDefault() is Image view &&
                view.WidthRequest + stackLayout.TranslationX < 0)
            {
                stackLayout.Children.Remove(view);
                stackLayout.Children.Add(view);
                stackLayout.TranslationX = view.TranslationX;
            }
        }
    }

    internal class player
    {
        internal static void Desenha()
        {
            throw new NotImplementedException();
        }
    }
}
