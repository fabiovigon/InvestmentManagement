using InvestmentManagement.Domain.Interfaces.IProductFinancial;
using InvestmentManagement.Entities.Entities;
using InvestmentManagement.Infra.Configurations;
using InvestmentManagement.Infra.Respositories.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.Infra.Respositories
{
    public class ProductFinancialRepository : RepositoriesGenerics<ProductFinancial>, IProductFinancial
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        public ProductFinancialRepository()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<ProductFinancial>> GetUserProductFinancialList(string userEmail)
        {
            using (var dbContext = new ContextBase(_optionsBuilder))
            {
                return await (from s in dbContext.FinancialSystems
                              join c in dbContext.Categories on s.Id equals c.IdSystem
                              join us in dbContext.UserFinancialSystem on s.Id equals us.IdSystem
                              join p in dbContext.ProductFinancial on c.Id equals p.IdCategory
                              where us.Email.Equals(userEmail) && s.Month == p.Month && s.Year == p.Year
                              select p).AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<ProductFinancial>> GetProductFinancialList()
        {
            using (var dbContext = new ContextBase(_optionsBuilder))
            {
                return await (from s in dbContext.FinancialSystems
                              join c in dbContext.Categories on s.Id equals c.IdSystem
                              join us in dbContext.UserFinancialSystem on s.Id equals us.IdSystem
                              join p in dbContext.ProductFinancial on c.Id equals p.IdCategory
                              select p).AsNoTracking().ToListAsync();
            }
        }

        public async Task NotifyAdminsAboutExpiringProducts()
        {
            using (var dbContext = new ContextBase(_optionsBuilder))
            {
                var productsExpiringSoon = await (from s in dbContext.FinancialSystems
                                                  join c in dbContext.Categories on s.Id equals c.IdSystem
                                                  join us in dbContext.UserFinancialSystem on s.Id equals us.IdSystem
                                                  join p in dbContext.ProductFinancial on c.Id equals p.IdCategory
                                                  where p.Dt_ExpiredProduct <= DateTime.UtcNow.AddDays(2)
                                                        && p.Dt_ExpiredProduct >= DateTime.UtcNow
                                                        && !p.ProductExpired
                                                  select p).ToListAsync();

                if (productsExpiringSoon.Any())
                {
                    foreach (var product in productsExpiringSoon)
                    {
                        // Enviar e-mail
                        //await _emailService.SendEmailToAdmins(product);

                        // Se o produto expirou, marque como expirado
                        if (product.Dt_ExpiredProduct <= DateTime.UtcNow)
                        {
                            product.ProductExpired = true;
                            dbContext.ProductFinancial.Update(product);
                        }
                    }

                    // Salvar as alterações (se necessário)
                    await dbContext.SaveChangesAsync();
                }
            }
        }


        //public async Task SendEmailToAdmins(ProductFinancial product)
        //{
        //    var mailMessage = new MailMessage
        //    {
        //        From = new MailAddress(_smtpUser),
        //        Subject = "Alerta: Produto Financeiro Prestes a Expirar",
        //        Body = $"O produto financeiro '{product.Name}' está prestes a expirar em {product.Dt_ExpiredProduct:dd/MM/yyyy}.",
        //        IsBodyHtml = true,
        //    };

        //    // Adiciona o email do administrador como destinatário
        //    mailMessage.To.Add(_adminEmail);

        //    using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort))
        //    {
        //        smtpClient.Credentials = new NetworkCredential(_smtpUser, _smtpPass);
        //        smtpClient.EnableSsl = true;

        //        await smtpClient.SendMailAsync(mailMessage);
        //    }
        //}
    }



}
//}
