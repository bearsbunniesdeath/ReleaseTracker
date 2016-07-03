Imports System.Globalization

''' <summary>
''' Converts a flaggable enum to a boolean that is true when parameter is set in value.
''' WARNING: Only use one converter per "set" of flags
''' </summary>
Public Class EnumFlagsToBooleanConverter
    Implements IValueConverter

    Private _targetValue As Integer

    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
        Dim mask = CType(parameter, Integer)
        _targetValue = value
        Return (mask And _targetValue)
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
        _targetValue = _targetValue Xor parameter
        Return [Enum].Parse(targetType, _targetValue.ToString())
    End Function
End Class
