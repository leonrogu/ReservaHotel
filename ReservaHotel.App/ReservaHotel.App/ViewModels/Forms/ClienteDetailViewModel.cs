using ReservaHotel.App.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ReservaHotel.App.ViewModels.Forms
{
    public class ClienteDetailViewModel : BaseViewModel
    {
        #region Attributes
        private ClienteDTO _clientes;
        //private ObservableCollection<StudentDTO> _students;
        private bool _isRefreshing;
        #endregion

        #region Properties
        public ClienteDTO Cliente
        {
            get { return _clientes; }
            set { this.SetValue(ref _clientes, value); }
        }

        /*public ObservableCollection<StudentDTO> Students
        {
            get { return _students; }
            set { this.SetValue(ref _students, value); }
        }*/

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { this.SetValue(ref _isRefreshing, value); }
        }
        #endregion

        public ClienteDetailViewModel(ClienteDTO cliente)
        {
            this.Cliente = cliente;
            //this.RefreshCommand = new Command(GetStudents);
           // this.RefreshCommand.Execute(null);
        }
        public ClienteDetailViewModel()
        {

        }

        public Command RefreshCommand { get; set; }
    }
}
