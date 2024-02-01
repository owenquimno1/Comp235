using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodLog
{
    public partial class FoodLog : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool checkFileType(string fileName) { 
        
            //static call to path class to get the extension of the file in question
            string ext = Path.GetExtension(fileName);

            switch (ext.ToLower())
            {
                case ".gif":
                    return true;
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }

        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // builds the file path using the destination path
            // ~ - is the root folder of our project
            // Images - this folder must exist on the root of the project
            // fuImage.FileName - reads the FileName property from the upload control

            //Build string to image path using solution folder and file control FileName attribute
            string filePath = "~/Images/" + fuImage.FileName;

            //Checks if the file extention is valid then saves the image

            if (checkFileType(filePath))
            {
                //Extract the form fields and assign them to the insert parameters of our
                //FoodLog DataSource, Insert Parameter matches the column names of our database table

                SQLFoodLog.InsertParameters["ItemName"].DefaultValue = txtItemName.Text;
                SQLFoodLog.InsertParameters["PreparedBy"].DefaultValue = txtPreparedBy.Text;
                SQLFoodLog.InsertParameters["ConsumedAt"].DefaultValue = txtConsumedAt.Text;
                SQLFoodLog.InsertParameters["MealType"].DefaultValue = ddlMealType.SelectedValue;
                SQLFoodLog.InsertParameters["ImagePath"].DefaultValue = filePath;


                //Call to insert items in insert parameters
                SQLFoodLog.Insert();


                //Save Image
                fuImage.SaveAs(MapPath(filePath));
            }
            else { 
            
                //notify the user of the error
                
            }

            

          

           

        }
    }
}