using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using BookHavenStoreApp.Models;

namespace BookHavenStoreApp.Helpers
{
    public class ReceiptPdfHelper
    {
        public static void GenerateReceipt(Order order, List<OrderItem> items, string filePath)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            Document.Create(doc =>
            {
                doc.Page(page =>
                {
                    page.Margin(30);
                    page.Size(PageSizes.A4);

                    page.Header().Text("BookHaven Store Receipt")
                        .SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);

                    page.Content().PaddingVertical(10).Column(column =>
                    {
                        column.Item().Text($"Order ID: {order.OrderID}");
                        column.Item().Text($"Customer ID: {order.CustomerID}");
                        column.Item().Text($"Date: {order.OrderDate:yyyy-MM-dd}");
                        column.Item().Text($"Status: {order.Status}");

                        column.Item().LineHorizontal(1).LineColor(Colors.Grey.Medium);

                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.RelativeColumn();
                                cols.ConstantColumn(80);
                                cols.ConstantColumn(80);
                                cols.ConstantColumn(80);
                            });

                            // Header
                            table.Header(header =>
                            {
                                header.Cell().Element(e => StyleHeaderCell(e)).Text("Book");
                                header.Cell().Element(e => StyleHeaderCell(e)).AlignRight().Text("Price");
                                header.Cell().Element(e => StyleHeaderCell(e)).AlignRight().Text("Qty");
                                header.Cell().Element(e => StyleHeaderCell(e)).AlignRight().Text("Total");
                            });

                            // Rows
                            foreach (var item in items)
                            {
                                table.Cell().Element(e => StyleRowCell(e)).Text(item.BookTitle);
                                table.Cell().Element(e => StyleRowCell(e)).AlignRight().Text($"{item.Price:C}");
                                table.Cell().Element(e => StyleRowCell(e)).AlignRight().Text(item.Quantity.ToString());
                                table.Cell().Element(e => StyleRowCell(e)).AlignRight().Text($"{item.Price * item.Quantity:C}");
                            }
                        });

                        column.Item().LineHorizontal(1).LineColor(Colors.Grey.Medium);
                        column.Item().Text($"Discount: {order.Discount:C}").AlignRight();
                        column.Item().Text($"Final Amount: {order.FinalAmount:C}").Bold().FontSize(14).AlignRight();
                    });

                    page.Footer().AlignCenter().Text("Thank you for shopping at BookHaven!");
                });
            }).GeneratePdf(filePath);
        }

        private static IContainer StyleHeaderCell(IContainer container)
        {
            return container.DefaultTextStyle(x => x.SemiBold())
                            .PaddingVertical(5)
                            .Background(Colors.Grey.Lighten3)
                            .BorderBottom(1)
                            .BorderColor(Colors.Grey.Medium);
        }

        private static IContainer StyleRowCell(IContainer container)
        {
            return container.PaddingVertical(5);
        }
    }
}
