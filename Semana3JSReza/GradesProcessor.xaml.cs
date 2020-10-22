using Semana3JSReza.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana3JSReza
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GradesProcessor : ContentPage
    {
        private List<Grade> lstQuotes = new List<Grade>() {
            new Grade{ Id=1,Quote= "Ingrese Nota Seguimiento 1",ConversionValue = 0.3},
            new Grade{ Id=2,Quote= "Ingrese Nota Examen 1",ConversionValue = 0.2},
            new Grade{ Id=3,Quote= "Ingrese Nota Seguimiento 2",ConversionValue = 0.3},
            new Grade{ Id=4,Quote= "Ingrese Nota Examen 2",ConversionValue = 0.2},
        };

        private int _index = 1;

        public GradesProcessor(User user)
        {
            BindingContext = user;            
            InitializeComponent();
        }

        private void btnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtNota.Text))
                {
                    if (Convert.ToDouble(txtNota.Text) < 0 ||
                        Convert.ToDouble(txtNota.Text) > 10)
                    {
                        lblMensaje.Text = "Nota fuera de Rango [0 - 10]";
                        return;
                    }

                    lstQuotes.SingleOrDefault(q => q.Id == _index).InputGrade
                        = Convert.ToDouble(txtNota.Text) * lstQuotes.SingleOrDefault(q => q.Id == _index).ConversionValue;
                }
                else
                {
                    lblMensaje.Text = "Ingresar la nota indicada";
                    return;
                }

                if (_index == 1)
                    lblMensaje.Text = string.Empty;

                if (_index == 2)
                    lblMensaje.Text = $"Nota Parcial 1 : {lstQuotes[0].InputGrade + lstQuotes[1].InputGrade}";

                if (_index == 4)
                {
                    double totalGrade = 0;
                    foreach (var quote in lstQuotes)
                        totalGrade += quote.InputGrade;

                    lblMensaje.Text = $"Parcial 1 : {lstQuotes[0].InputGrade + lstQuotes[1].InputGrade} \n" +
                                      $"Parcial 2 : {lstQuotes[2].InputGrade + lstQuotes[3].InputGrade} \n" +
                                      $"Nota Total : {totalGrade} \n" +
                                      $"{(totalGrade >= 7 ? "Aprobado" : "Reprobado")}";
                }

                if (_index < lstQuotes.Count)
                    _index++;
                else
                    _index = 1;

                txtNota.Text = string.Empty;
                txtNota.Placeholder = lstQuotes.SingleOrDefault(q => q.Id == _index).Quote;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error: {ex.Message}";
            }
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            if (_index > 1)
                _index--;

            txtNota.Text = string.Empty;

            if (_index == 1 || _index == 3)
                lblMensaje.Text = string.Empty;

            txtNota.Placeholder = lstQuotes.SingleOrDefault(q => q.Id == _index).Quote;
        }
    }    
}
