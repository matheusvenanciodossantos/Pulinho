namespace Pulinho;

public partial class MainPage : ContentPage
{
	//Atributos//
	//------------------------------------------------------------------------//

	bool Faliceu = false;
	// se está morto

	bool Pulinho = false;
	//se está pulando

	//------------------------------------------------------------------------//

	const int FPS = 25;
	//fps

	//------------------------------------------------------------------------//

	int Speed1 = 0;
	//velocidade da primeira camada no caso 
	// a camada que fica por ultimo

	int Speed2 = 0;
	//velocidade da segunda camada

	int Speed3 = 0;
	// velocidade da terceira camada

	int SpeedChao_Boneco = 0;
	//velocidade do chão ou do boneco tbm

	int altura = 0;
	//altura da janela 

	int largura = 0;
	//largura da janela

	//------------------------------------------------------------------------//

	public MainPage()
	{
		InitializeComponent();
	}


	//------------------------------------------------------------------------//



	//------------------------------------------------------------------------//
	protected override void OnSizeAllocated(double w, double h)
	{
		base.OnSizeAllocated(w, h);
		FixScreenSize(w, h);
		CalculateSpeed(w);
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		Drawn();
	}
	//------------------------------------------------------------------------//

	void FixScreenSize(double w, double h)
	{
		foreach (var A in HSLayerOne.Children)
			(A as Image).WidthRequest = w;
		foreach (var A in HSLayerTwo.Children)
			(A as Image).WidthRequest = w;
		foreach (var A in HSLayerThree.Children)
			(A as Image).WidthRequest = w;
		foreach (var A in HSLayerPrimalfloor.Children)
			(A as Image).WidthRequest = w;

		HSLayerOne.WidthRequest = w * 1.5;
		HSLayerTwo.WidthRequest = w * 1.5;
		HSLayerThree.WidthRequest = w * 1.5;
		HSLayerPrimalfloor.WidthRequest = w * 1.5;
	}

	//------------------------------------------------------------------------//
	void CalculateSpeed(double w)
	{
		Speed1 = (int)(w * 0.001);
		Speed2 = (int)(w * 0.004);
		Speed3 = (int)(w * 0.008);
		SpeedChao_Boneco = (int)(w * 0.01);
	}

	//------------------------------------------------------------------------//
	async Task Drawn()
	{
		while (!Faliceu)
		{
			ManageScenes();
			await Task.Delay(FPS);
		}
	}

	//------------------------------------------------------------------------//
	void MoveScene()
	{
		HSLayerOne.TranslationX -= Speed1;
		HSLayerTwo.TranslationX -= Speed2;
		HSLayerThree.TranslationX -= Speed3;
		HSLayerPrimalfloor.TranslationX -= SpeedChao_Boneco;
	}

	//------------------------------------------------------------------------//
	void ManageScenes()
	{
		MoveScene();
		ManageScene(HSLayerOne);
		ManageScene(HSLayerTwo);
		ManageScene(HSLayerThree);
		ManageScene(HSLayerPrimalfloor);
	}


	//------------------------------------------------------------------------//

	void ManageScene(HorizontalStackLayout HSL)
	{
		var view = (HSL.Children.First() as Image);
		if (view.WidthRequest + HSL.TranslationX < 0)
		{
			HSL.Children.Remove(view);
			HSL.Children.Add(view);
			HSL.TranslationX = view.TranslationX;
		}
	}

	

	//------------------------------------------------------------------------//
}