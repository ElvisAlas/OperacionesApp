namespace OperacionesApp.View
{

	public partial class DivisiónPage : ContentPage
	{
		public DivisiónPage()
		{
			InitializeComponent();
		}
        private void OnSumarClicked(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                double v1 = Convert.ToDouble(valor1.Text);
                double v2 = Convert.ToDouble(valor2.Text);



                double resultado = v1 / v2;


                resultadoLabel.Text = $"Resultado: {resultado}";
                MostrarNotificacion("Se realizo la operacion de Division");
            }
        }
        private void OnLimpiarCamposClicked(object sender, EventArgs e)
        {
            valor1.Text = "";
            valor2.Text = "";

            resultadoLabel.Text = "";
        }
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(valor1.Text) || string.IsNullOrWhiteSpace(valor2.Text) || Convert.ToDouble(valor2.Text)== 0 )
            {
                resultadoLabel.Text = "Todos los campos son obligatorios.";

                return false;
            }

            return true;
        }

        private void MostrarNotificacion(string mensaje)
        {

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await App.Current.MainPage.DisplayAlert("Notificación", mensaje, "OK");
            });
        }
    }
}