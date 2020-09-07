namespace Sales.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    // Esta clase es la que implementa la INotifyPropertyChanged y tiene un metodo que se llama SetValue 
    // que es un metodo generico que sirve para que me refresque cualquier campo

    // este codigo sirve para rrefrescar automaticamente lo que hagammos en las propiedades
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
            {
                return;
            }

            backingField = value;
            this.OnPropertyChanged(propertyName);
        }
    }
}
