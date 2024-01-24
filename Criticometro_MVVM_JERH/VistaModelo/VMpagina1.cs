using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static Xamarin.Essentials.Permissions;

namespace Criticometro_MVVM_JERH.VistaModelo
{
    public class VMpagina1 : BaseViewModel
    {

        #region VARIABLES


        string _Nombre;
        string _Critica;
        bool _SexoHombre;
        bool _SexoMujer;

        bool _Alto;
        bool _Lista;
        bool _Raro;
        bool _Feo;
        bool _Extrabagante;
        bool _Grande;


        #endregion
        #region Contructor
        public VMpagina1(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region Objetivo;
        public string Nombre
        {
            get { return _Nombre; }
            set { SetValue(ref _Nombre, value); }
        }

        public bool SexoHombre
        {
            get { return _SexoHombre; }
            set { SetValue(ref _SexoHombre, value); }
        }

        public bool SexoMujer
        {
            get { return _SexoMujer; }
            set { SetValue(ref _SexoMujer, value); }
        }

        public bool Alto
        {
            get { return _Alto; }
            set { SetValue(ref _Alto, value); }
        }
        public bool Listo
        {
            get { return _Lista; }
            set { SetValue(ref _Lista, value); }
        }
        public bool Raro
        {
            get { return _Raro; }
            set { SetValue(ref _Raro, value); }
        }
        public bool Feo
        {
            get { return _Feo; }
            set { SetValue(ref _Feo, value); }
        }
        public bool Extrabagante
        {
            get { return _Extrabagante; }
            set { SetValue(ref _Extrabagante, value); }
        }
        public bool Grande
        {
            get { return _Grande; }
            set { SetValue(ref _Grande, value); }
        }
        public string Critica
        {
            get { return _Critica; }
            set { SetValue(ref _Critica, value); }
        }
        /*
        public string SeleccionarTipoUsuario
        {
            get { return _TipoUsuario; }
            set
            {
                SetValue(ref _TipoUsuario, value);
                TipoUsuario = _TipoUsuario;
            }
        }
        */
        #endregion

        #region PROCESOS




        public void Criticar()
        {
            Critica ="";
            Critica += _Nombre + " es";

            int cont = 0;
            if (Alto)
            {
                Critica += _SexoHombre ? " , alto" : " , alta";
                cont++;
            }
            if (Feo)
            {
                Critica += _SexoHombre ? " , feo" : " , fea";
                cont++;
            }
            if (Listo)
            {
                Critica += _SexoHombre ? " , listo" : " , lista";
                cont++;
            }
            if (Extrabagante)
            {
                Critica += " , extrabagante";
                cont++;
            }
            if (Raro)
            {
                Critica += _SexoHombre ? " , raro" : " , rara";
                cont++;
            }
            if (Grande)
            {
                Critica += " " +
                    ", grande";
                cont++;
            }

            Yepunto(cont);
            Critica = Critica.ToString();
        }

        public void Validaciones()
        {
            //validacion del nombre diferente a nulo 
            if (Nombre != null)
            {
                if (SexoHombre==true||SexoMujer==true) {

                    if (Alto == true ||  Raro== true || Feo == true || Extrabagante == true || Listo == true || Grande == true)
                    {

                        Criticar();

                    }
                    else
                    {
                        DisplayAlert("Datos Incorrectos", "Seleccione algunas de las carracteristicas", "Cerrar");
                    }

                }
                else {
                    DisplayAlert("Datos Incorrectos", "Seleccione el sexo", "Cerrar");
                }
            }
            else
                DisplayAlert("Datos Incorrectos", "Ingrese el nombre", "Cerrar");
        }


        public void Yepunto(int cont)
        {
            int contador = 0;

            for (int i = 0; i < Critica.Length; i++)
            {
                if (Critica[i] == ',')
                {
                    contador++;

                    if (contador == 1)
                    {
                        // Elimina la primera coma encontrada
                        Critica = Critica.Remove(i, 1);
                    }
                    else if (contador == cont && contador > 1)
                    {
                        // Reemplaza la última coma con 'y'
                        Critica = Critica.Substring(0, i) + 'y' + Critica.Substring(i + 1);
                        contador++;
                    }
                }
            }

            // Agrega un punto al final de la cadena
            Critica += ".";
        }

        #endregion.

        #region COMANDOS

        public ICommand Criticarcommand => new Command(Validaciones);
        #endregion

    }
}
