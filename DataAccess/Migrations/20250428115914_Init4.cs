using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Brand_BrandId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCar_Car_CarId",
                table: "CustomerCar");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCar_Users_CustomerId",
                table: "CustomerCar");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_CustomerCar_CustomersCarId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_AdministratorId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_EmployeeId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderService_Order_OrderId",
                table: "OrderService");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderService_Service_ServiceId",
                table: "OrderService");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Role_RoleId",
                table: "RoleUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Users_UserId",
                table: "RoleUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleUser",
                table: "RoleUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderService",
                table: "OrderService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerCar",
                table: "CustomerCar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Car",
                table: "Car");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brand",
                table: "Brand");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "RoleUser",
                newName: "RoleUsers");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "OrderService",
                newName: "OrderServices");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "CustomerCar",
                newName: "CustomerCars");

            migrationBuilder.RenameTable(
                name: "Car",
                newName: "Cars");

            migrationBuilder.RenameTable(
                name: "Brand",
                newName: "Brands");

            migrationBuilder.RenameIndex(
                name: "IX_RoleUser_UserId",
                table: "RoleUsers",
                newName: "IX_RoleUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleUser_RoleId",
                table: "RoleUsers",
                newName: "IX_RoleUsers_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderService_ServiceId",
                table: "OrderServices",
                newName: "IX_OrderServices_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderService_OrderId",
                table: "OrderServices",
                newName: "IX_OrderServices_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_EmployeeId",
                table: "Orders",
                newName: "IX_Orders_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CustomersCarId",
                table: "Orders",
                newName: "IX_Orders_CustomersCarId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_AdministratorId",
                table: "Orders",
                newName: "IX_Orders_AdministratorId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerCar_CustomerId",
                table: "CustomerCars",
                newName: "IX_CustomerCars_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerCar_CarId",
                table: "CustomerCars",
                newName: "IX_CustomerCars_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Car_BrandId",
                table: "Cars",
                newName: "IX_Cars_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleUsers",
                table: "RoleUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderServices",
                table: "OrderServices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerCars",
                table: "CustomerCars",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Brands_BrandId",
                table: "Cars",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCars_Cars_CarId",
                table: "CustomerCars",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCars_Users_CustomerId",
                table: "CustomerCars",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CustomerCars_CustomersCarId",
                table: "Orders",
                column: "CustomersCarId",
                principalTable: "CustomerCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_AdministratorId",
                table: "Orders",
                column: "AdministratorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_EmployeeId",
                table: "Orders",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServices_Orders_OrderId",
                table: "OrderServices",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServices_Services_ServiceId",
                table: "OrderServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUsers_Roles_RoleId",
                table: "RoleUsers",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUsers_Users_UserId",
                table: "RoleUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Brands_BrandId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCars_Cars_CarId",
                table: "CustomerCars");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCars_Users_CustomerId",
                table: "CustomerCars");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CustomerCars_CustomersCarId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_AdministratorId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_EmployeeId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderServices_Orders_OrderId",
                table: "OrderServices");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderServices_Services_ServiceId",
                table: "OrderServices");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUsers_Roles_RoleId",
                table: "RoleUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUsers_Users_UserId",
                table: "RoleUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleUsers",
                table: "RoleUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderServices",
                table: "OrderServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerCars",
                table: "CustomerCars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.RenameTable(
                name: "RoleUsers",
                newName: "RoleUser");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "OrderServices",
                newName: "OrderService");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "CustomerCars",
                newName: "CustomerCar");

            migrationBuilder.RenameTable(
                name: "Cars",
                newName: "Car");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Brand");

            migrationBuilder.RenameIndex(
                name: "IX_RoleUsers_UserId",
                table: "RoleUser",
                newName: "IX_RoleUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleUsers_RoleId",
                table: "RoleUser",
                newName: "IX_RoleUser_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderServices_ServiceId",
                table: "OrderService",
                newName: "IX_OrderService_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderServices_OrderId",
                table: "OrderService",
                newName: "IX_OrderService_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_EmployeeId",
                table: "Order",
                newName: "IX_Order_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomersCarId",
                table: "Order",
                newName: "IX_Order_CustomersCarId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_AdministratorId",
                table: "Order",
                newName: "IX_Order_AdministratorId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerCars_CustomerId",
                table: "CustomerCar",
                newName: "IX_CustomerCar_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerCars_CarId",
                table: "CustomerCar",
                newName: "IX_CustomerCar_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_BrandId",
                table: "Car",
                newName: "IX_Car_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleUser",
                table: "RoleUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderService",
                table: "OrderService",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerCar",
                table: "CustomerCar",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Car",
                table: "Car",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brand",
                table: "Brand",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Brand_BrandId",
                table: "Car",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCar_Car_CarId",
                table: "CustomerCar",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCar_Users_CustomerId",
                table: "CustomerCar",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_CustomerCar_CustomersCarId",
                table: "Order",
                column: "CustomersCarId",
                principalTable: "CustomerCar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_AdministratorId",
                table: "Order",
                column: "AdministratorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_EmployeeId",
                table: "Order",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderService_Order_OrderId",
                table: "OrderService",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderService_Service_ServiceId",
                table: "OrderService",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Role_RoleId",
                table: "RoleUser",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Users_UserId",
                table: "RoleUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
