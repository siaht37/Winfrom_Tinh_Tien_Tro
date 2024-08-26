using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InvoiceService
{
    private readonly DBContext _context;

    public InvoiceService(DBContext context)
    {
        _context = context;
    }

    public InvoiceDTO GetById(int id)
    {
        // Lấy dữ liệu từ cơ sở dữ liệu
        var invoice = _context.Invoices.Find(id);
        // Chuyển đổi dữ liệu sau khi truy xuất
        return invoice == null ? null : ConvertToDTO(invoice);
    }

    public IEnumerable<InvoiceDTO> GetAll()
    {
        // Lấy dữ liệu từ cơ sở dữ liệu
        var invoices = _context.Invoices.ToList();
        // Chuyển đổi dữ liệu sau khi truy xuất
        return invoices.Select(invoice => ConvertToDTO(invoice)).ToList();
    }

    public void Update(InvoiceDTO invoiceDTO)
    {
        var existingInvoice = _context.Invoices.Find(invoiceDTO.InvoiceID);
        if (existingInvoice != null)
        {
            existingInvoice.RoomID = invoiceDTO.RoomID;
            existingInvoice.Month = invoiceDTO.Month;
            existingInvoice.ElectricityCharge = invoiceDTO.ElectricityCharge;
            existingInvoice.WaterCharge = invoiceDTO.WaterCharge;
            existingInvoice.RoomCharge = invoiceDTO.RoomCharge;
            existingInvoice.TotalAmount = invoiceDTO.TotalAmount;
            existingInvoice.Status = invoiceDTO.Status;
            _context.SaveChanges();
        }
    }
    public void Add(InvoiceDTO invoiceDTO)
    {
        var invoice = new Invoice
        {
            RoomID = invoiceDTO.RoomID,
            Month = invoiceDTO.Month,
            ElectricityCharge = invoiceDTO.ElectricityCharge,
            WaterCharge = invoiceDTO.WaterCharge,
            RoomCharge = invoiceDTO.RoomCharge,
            TotalAmount = invoiceDTO.TotalAmount,
            Status = invoiceDTO.Status
        };

        _context.Invoices.Add(invoice);
        _context.SaveChanges();
    }


    private InvoiceDTO ConvertToDTO(Invoice invoice)
    {
        return new InvoiceDTO
        {
            InvoiceID = invoice.InvoiceID,
            RoomID = invoice.RoomID,
            Month = invoice.Month,
            ElectricityCharge = invoice.ElectricityCharge,
            WaterCharge = invoice.WaterCharge,
            RoomCharge = invoice.RoomCharge,
            TotalAmount = invoice.TotalAmount,
            Status = invoice.Status
        };
    }
}
