// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyView.xaml.cs" company="Geert van Horrik">
//   Copyright (c) 2008 - 2018 Geert van Horrik. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Ghk.MultiTargeting.Views
{
    public partial class MyView
    {
        public MyView()
        {
            InitializeComponent();

            Construct();
        }

        partial void Construct();
    }
}