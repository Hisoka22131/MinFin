namespace MinFin.Parse.Helpers;

public static class ConvertHelper
{
    /// <summary>
    /// Конвертирование моделей с помощью рефелксии
    /// todo: Сейчас используется маппер
    /// </summary>
    /// <param name="sendModel">Модель в которую надо записать</param>
    /// <param name="model">Модель из которой надо записать</param>
    public static void Convert<TSend, TModel>(TSend sendModel, TModel model) where TSend : class where TModel : class
    {
        var modelProperties = typeof(TModel).GetProperties();
        var sendDtoProperties = typeof(TSend).GetProperties();

        foreach (var sendDtoProperty in sendDtoProperties)
        {
            var correspondingModelProperty = modelProperties.FirstOrDefault(p =>
                p.Name.Equals(sendDtoProperty.Name, StringComparison.OrdinalIgnoreCase) &&
                p.PropertyType == sendDtoProperty.PropertyType);

            if (correspondingModelProperty != null)
            {
                sendDtoProperty.SetValue(sendModel, correspondingModelProperty.GetValue(model));
            }
        }
    }
}