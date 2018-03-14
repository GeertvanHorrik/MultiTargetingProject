// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyView.xaml.cs" company="Geert van Horrik">
//   Copyright (c) 2008 - 2018 Geert van Horrik. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Ghk.MultiTargeting.Views
{
    using Catel.MVVM.Views;

#if NET
    using System.Windows;
#elif NETFX_CORE
    using Windows.UI.Xaml;
#endif

    public partial class MyView
    {
        static MyView()
        {
            typeof(MyView).AutoDetectViewPropertiesToSubscribe();
        }

        partial void Construct()
        {
            // TODO: Add shared constructor info here
        }

        [ViewToViewModel(MappingType = ViewToViewModelMappingType.TwoWayViewWins)]
        public string Scope
        {
            get { return (string)GetValue(ScopeProperty); }
            set { SetValue(ScopeProperty, value); }
        }

        public static readonly DependencyProperty ScopeProperty = DependencyProperty.Register("Scope", typeof(string), 
            typeof(MyView), new PropertyMetadata(null));
    }
}