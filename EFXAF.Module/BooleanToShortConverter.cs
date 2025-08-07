// Lokalizacja: EFXAF.Module/BooleanToShortConverter.cs

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFXAF.Module.BusinessObjects
{
    public class BooleanToShortConverter : ValueConverter<bool, short>
    {
        public BooleanToShortConverter() : base(
            // Funkcja konwertująca z bool (model) na short (baza danych)
            v => (short)(v ? 1 : 0),

            // Funkcja konwertująca z short (baza danych) na bool (model)
            v => v == 1
        )
        {
        }
    }
}