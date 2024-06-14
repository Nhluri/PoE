# PoE
                                       PART3
RecipeAppWPF is a WPFApp for recipes. This will focus on features for listing recipes and visualizing the distribution of food groups using a pie chart.

 Table of Contents
  [Requirements]
  [Installation]
  [Running the Application]
  [Updates]
  
                                     Requirements

Visual Studio 2022 or later
.NET Framework 4.7.2
DotNetProjects.WpfToolkit.DataVisualization NuGet package

Open the solution in Visual Studio:

                                   Launch Visual Studio.
Go to File -> Open -> Project.
Navigate to the cloned directory and open RecipeAppWPF.sln.

                                   Restore NuGet packages:
In Solution Explorer, right-click on the solution and select Restore NuGet Packages.
Open the Project: Open the RecipeAppWPF project in Visual Studio.
Restore NuGet Packages: Ensure all NuGet packages are restored by right-clicking on the solution and selecting Restore NuGet Packages.
Build Solution: Go to Build > Build Solution to compile the project.
Run the Application: Click on the Start button.
                                   links
https://github.com/Nhluri/PoE/edit/main/README.md


                                     Updates
In the RecipeAppWPF project, several updates and enhancements were added to improve functions and user experience. Initially, the project was set up with a basic structure and integrated with the DotNetProjects.WpfToolkit.DataVisualization package for charting capabilities. A PieChartPage.xaml was created to visualize food group distribution using a pie chart, and a PieChartData class was introduced to represent the data points. Styling enhancements were made to include a gradient background and custom button styles, improving the overall UI. Namespace and assembly references were adjusted to ensure proper loading and integration of the toolkit. Bugs related to namespace declarations and data binding were resolved, ensuring the pie chart functionality worked seamlessly with the recipe listing. Finally, navigation features, such as a back button, were implemented to enhance user experience and application usability.
