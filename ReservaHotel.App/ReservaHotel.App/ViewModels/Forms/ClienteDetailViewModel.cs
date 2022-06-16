using ReservaHotel.App.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;

namespace ReservaHotel.App.ViewModels.Forms
{
    public class ClienteDetailViewModel : BaseViewModel
    {
        #region Attributes
        private ClienteDTO _cliente;
        private ObservableCollection<ReservaDTO> _reservas;
        private bool _isRefreshing;
        #endregion

        #region Properties
        public ClienteDTO Cliente
        {
            get { return _cliente; }
            set { this.SetValue(ref _cliente, value); }
        }

        public ObservableCollection<ReservaDTO> Reservas
        {
            get { return _reservas; }
            set { this.SetValue(ref _reservas, value); }
        }

        /*public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { this.SetValue(ref _isRefreshing, value); }
        }*/
        #endregion

        public ClienteDetailViewModel(ClienteDTO cliente)
        {
            this.Cliente = cliente;
            this.RefreshCommand = new Command(GetReservas);
            this.RefreshCommand.Execute(null);
        }

        public ClienteDetailViewModel()
        {

        }

        async void GetReservas()
        {
            this.IsRefreshing = true;
            var url = "https://62a672f5430ba53411d4cfc0.mockapi.io/api/reservahotel/reserva";
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    /*var reservas = JsonConvert.DeserializeObject<ObservableCollection<ReservaDTO>>(result);
                    var reservasFilter = reservas.Where(x => x.CourseID == _course.CourseID).ToList();
                    this.Students = new ObservableCollection<StudentDTO>(studentsFilter);*/
                }
            }
            this.IsRefreshing = false;
        }

        public Command RefreshCommand { get; set; }
    }
}

