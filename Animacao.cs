namespace pulinho;

public class Animacao
{
    protected List<string> animacao1 = new List<string>();
    protected List<string> animacao2 = new List<string>();
    protected List<string> animacao3 = new List<string>();
    protected int animacaoAtiva = 1;
    int frameAtual = 1;
    protected bool loop = true;
    bool parado = false;
    protected CachedImage compImage;

    public Animacao(CachedImage a)
    {
        compImage = a;
    }

    public void Stop()
    {
        parado = true;
    }

    public void Play()
    {
        parado = false;
    }

    public void SetAnimacaoAtiva(int a)
    {
        animacaoAtiva = a;
    }

    public void Desenha()
    {
        if(parado)
            return;
        
        string nomeArquivo = "goku";
        int tamanhoAnimacao = 1;

        if(animacaoAtiva == 1)
        {
            nomeArquivo = animacao1[frameAtual];
            tamanhoAnimacao = animacao1.Count;
        }
        else if(animacaoAtiva == 2)
        {
            nomeArquivo = animacao2[frameAtual];
            tamanhoAnimacao = animacao2.Count;
        }
        else if(animacaoAtiva == 3)
        {
            nomeArquivo = animacao3[frameAtual];
            tamanhoAnimacao = animacao3.Count;
        }

        compImage.Source = ImageSource.FromFile(nomeArquivo);
        frameAtual++;

        if(frameAtual >= tamanhoAnimacao)
        {
            if(loop)
                frameAtual = 0;
            else
            {
                parado = true;
                QuandoParar();
            }
        }
    }

    public virtual void QuandoParar()
    {
        
    }
}