﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MainPackage.Model;
using System.Collections;

namespace HospitalTeam12.Model
{
    /// <summary>
    /// Interaction logic for RecipeSearch.xaml
    /// </summary>
    public partial class RecipeSearch : Window
    {
        public ArrayList res { get; set; }
        public RecipeSearch()
        {
            InitializeComponent();

            this.DataContext = this;

        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            var mr = new MedicalRecord();
            res = mr.GetRecipes(recipeID.Text);
            dataGridRecipe.ItemsSource = res;
        }
    }
}
