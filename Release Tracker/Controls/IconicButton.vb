Imports FontAwesome.WPF

Public Class IconicButton
    Inherits Button

    Public Shared ReadOnly IconProperty As DependencyProperty
    Public Shared ReadOnly CaptionProperty As DependencyProperty

    Shared Sub New()
        DefaultStyleKeyProperty.OverrideMetadata(GetType(IconicButton),
                                                 New FrameworkPropertyMetadata(GetType(IconicButton)))

        IconProperty = DependencyProperty.Register("Icon", GetType(FontAwesomeIcon), GetType(IconicButton),
                                    New UIPropertyMetadata(FontAwesomeIcon.Apple))

        CaptionProperty = DependencyProperty.Register("Caption", GetType(String), GetType(IconicButton),
                                    New UIPropertyMetadata("Caption"))
    End Sub

    Public Property Icon As FontAwesomeIcon
        Get
            Return CType(GetValue(IconProperty), FontAwesomeIcon)
        End Get
        Set(value As FontAwesomeIcon)
            SetValue(IconProperty, value)
        End Set
    End Property

    Public Property Caption As String
        Get
            Return CType(GetValue(CaptionProperty), String)
        End Get
        Set(value As String)
            SetValue(CaptionProperty, value)
        End Set
    End Property

End Class

