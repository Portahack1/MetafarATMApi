using Metafar.ATM.Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metafar.ATM.Persistence.Configuration
{
    public class TransactionConfiguration
    {
        public TransactionConfiguration(EntityTypeBuilder<TransactionEntity> entityBuilder)
        {
            entityBuilder.ToTable("Transaction");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.AccountNumber).IsRequired();
            entityBuilder.Property(x => x.TransactionDate).IsRequired();
            entityBuilder.Property(x => x.Amount).IsRequired();

            entityBuilder.HasOne(x => x.TransactionType);
            entityBuilder
                .HasOne(x => x.Account)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.AccountNumber);

            entityBuilder.HasData(
                new TransactionEntity()
                {
                    Id = new Guid("B98C3D44-D31B-4DD4-A90B-B4F7A94F55D6"),
                    AccountNumber = "33294946862678791686",
                    TransactionTypeId = new Guid("9EC43875-4446-4F52-8DAA-967C2D938C7B"),
                    TransactionDate = DateTime.Now.AddDays(-20),
                    Amount = 50
                },
                new TransactionEntity()
                {
                    Id = new Guid("A19E51BB-D427-4911-BB00-A16BDDCF7ED1"),
                    AccountNumber = "33294946862678791686",
                    TransactionTypeId = new Guid("9EC43875-4446-4F52-8DAA-967C2D938C7B"),
                    TransactionDate = DateTime.Now.AddDays(-20),
                    Amount = 100
                },
                new TransactionEntity()
                {
                    Id = new Guid("132C5914-10BF-46DE-B1FE-6EC966759442"),
                    AccountNumber = "33294946862678791686",
                    TransactionTypeId = new Guid("9EC43875-4446-4F52-8DAA-967C2D938C7B"),
                    TransactionDate = DateTime.Now.AddDays(-19),
                    Amount = 100
                },
                new TransactionEntity()
                {
                    Id = new Guid("65760A63-26B8-4B6C-9368-DC3F29E5FB98"),
                    AccountNumber = "33294946862678791686",
                    TransactionTypeId = new Guid("F79CA38A-D81E-4C51-9B5F-741626A6BA18"),
                    TransactionDate = DateTime.Now.AddDays(-18),
                    Amount = 0
                },
                new TransactionEntity()
                {
                    Id = new Guid("4DC2ABEE-71B1-4B56-84E5-B0BB71A87EA9"),
                    AccountNumber = "33294946862678791686",
                    TransactionTypeId = new Guid("4142DE52-7053-478B-804B-B6BFA4217F1E"),
                    TransactionDate = DateTime.Now.AddDays(-17),
                    Amount = 750
                },
                new TransactionEntity()
                {
                    Id = new Guid("C660D4F4-539D-442E-ACDB-4AC5E33611BF"),
                    AccountNumber = "33294946862678791686",
                    TransactionTypeId = new Guid("4142DE52-7053-478B-804B-B6BFA4217F1E"),
                    TransactionDate = DateTime.Now.AddDays(-17),
                    Amount = 2000
                },
                new TransactionEntity()
                {
                    Id = new Guid("DB10B31F-3641-473C-B238-0BD6D3A883A5"),
                    AccountNumber = "33294946862678791686",
                    TransactionTypeId = new Guid("F79CA38A-D81E-4C51-9B5F-741626A6BA18"),
                    TransactionDate = DateTime.Now.AddDays(-16),
                    Amount = 0
                },
                new TransactionEntity()
                {
                    Id = new Guid("7D0E15C9-DE77-4A61-8294-D4EB23D2CD7C"),
                    AccountNumber = "33294946862678791686",
                    TransactionTypeId = new Guid("4142DE52-7053-478B-804B-B6BFA4217F1E"),
                    TransactionDate = DateTime.Now.AddDays(-15),
                    Amount = 500
                },
                new TransactionEntity()
                {
                    Id = new Guid("A8701937-E4FF-4330-8E09-EB93EE884A3F"),
                    AccountNumber = "33294946862678791686",
                    TransactionTypeId = new Guid("F79CA38A-D81E-4C51-9B5F-741626A6BA18"),
                    TransactionDate = DateTime.Now.AddDays(-14),
                    Amount = 0
                },
                // -------------------------------------------------
                // -------------------------------------------------
                // -------------------------------------------------
                // -------------------------------------------------
                new TransactionEntity()
                {
                    Id = new Guid("0CF6BF42-CC5B-48AB-DFDE-08DCC2959449"),
                    AccountNumber = "57580242539941657006",
                    TransactionTypeId = new Guid("9EC43875-4446-4F52-8DAA-967C2D938C7B"),
                    TransactionDate = DateTime.Now.AddDays(-20),
                    Amount = 150
                },
                new TransactionEntity()
                {
                    Id = new Guid("C8937602-D923-47A4-DFDD-08DCC2959449"),
                    AccountNumber = "57580242539941657006",
                    TransactionTypeId = new Guid("F79CA38A-D81E-4C51-9B5F-741626A6BA18"),
                    TransactionDate = DateTime.Now.AddDays(-20),
                    Amount = 0
                },
                new TransactionEntity()
                {
                    Id = new Guid("28257E7C-4B50-4F57-EA6A-08DCC294F655"),
                    AccountNumber = "57580242539941657006",
                    TransactionTypeId = new Guid("F79CA38A-D81E-4C51-9B5F-741626A6BA18"),
                    TransactionDate = DateTime.Now.AddDays(-19),
                    Amount = 0
                },
                new TransactionEntity()
                {
                    Id = new Guid("00DFB276-131F-4698-EA69-08DCC294F655"),
                    AccountNumber = "57580242539941657006",
                    TransactionTypeId = new Guid("9EC43875-4446-4F52-8DAA-967C2D938C7B"),
                    TransactionDate = DateTime.Now.AddDays(-19),
                    Amount = 1000
                },
                new TransactionEntity()
                {
                    Id = new Guid("C1634965-4447-4CAF-B2FB-77D4A461A139"),
                    AccountNumber = "57580242539941657006",
                    TransactionTypeId = new Guid("9EC43875-4446-4F52-8DAA-967C2D938C7B"),
                    TransactionDate = DateTime.Now.AddDays(-18),
                    Amount = 500
                },
                new TransactionEntity()
                {
                    Id = new Guid("9B32CEBC-6E82-4481-9719-8FB989DBC89F"),
                    AccountNumber = "57580242539941657006",
                    TransactionTypeId = new Guid("F79CA38A-D81E-4C51-9B5F-741626A6BA18"),
                    TransactionDate = DateTime.Now.AddDays(-17),
                    Amount = 0
                },
                new TransactionEntity()
                {
                    Id = new Guid("54442D6F-80F0-4E19-90D5-E6CA1198C891"),
                    AccountNumber = "57580242539941657006",
                    TransactionTypeId = new Guid("9EC43875-4446-4F52-8DAA-967C2D938C7B"),
                    TransactionDate = DateTime.Now.AddDays(-17),
                    Amount = 2100
                },
                new TransactionEntity()
                {
                    Id = new Guid("1BA6B48D-D481-49E0-9D7E-605EC6A7914A"),
                    AccountNumber = "57580242539941657006",
                    TransactionTypeId = new Guid("9EC43875-4446-4F52-8DAA-967C2D938C7B"),
                    TransactionDate = DateTime.Now.AddDays(-17),
                    Amount = 500
                },
                new TransactionEntity()
                {
                    Id = new Guid("652D4F5F-C122-4630-A14C-7CCE1855949C"),
                    AccountNumber = "57580242539941657006",
                    TransactionTypeId = new Guid("4142DE52-7053-478B-804B-B6BFA4217F1E"),
                    TransactionDate = DateTime.Now.AddDays(-16),
                    Amount = 10000
                },
                new TransactionEntity()
                {
                    Id = new Guid("122CB712-1867-4AC6-9E83-DAEF582E7F3F"),
                    AccountNumber = "57580242539941657006",
                    TransactionTypeId = new Guid("F79CA38A-D81E-4C51-9B5F-741626A6BA18"),
                    TransactionDate = DateTime.Now.AddDays(-16),
                    Amount = 0
                },
                new TransactionEntity()
                {
                    Id = new Guid("4AED7169-34EB-42D4-9AF9-5891DFA23D1A"),
                    AccountNumber = "57580242539941657006",
                    TransactionTypeId = new Guid("F79CA38A-D81E-4C51-9B5F-741626A6BA18"),
                    TransactionDate = DateTime.Now.AddDays(-15),
                    Amount = 0
                },
                new TransactionEntity()
                {
                    Id = new Guid("0DA4C8AB-9B1F-4856-A168-7F7299C50BB9"),
                    AccountNumber = "57580242539941657006",
                    TransactionTypeId = new Guid("9EC43875-4446-4F52-8DAA-967C2D938C7B"),
                    TransactionDate = DateTime.Now.AddDays(-14),
                    Amount = 600
                },
                new TransactionEntity()
                {
                    Id = new Guid("C4179123-BEDD-4F8E-9C78-B4E30B2D4CBE"),
                    AccountNumber = "57580242539941657006",
                    TransactionTypeId = new Guid("F79CA38A-D81E-4C51-9B5F-741626A6BA18"),
                    TransactionDate = DateTime.Now.AddDays(-14),
                    Amount = 0
                },
                new TransactionEntity()
                {
                    Id = new Guid("18B39627-C344-4B86-87A5-9D19B105426C"),
                    AccountNumber = "57580242539941657006",
                    TransactionTypeId = new Guid("4142DE52-7053-478B-804B-B6BFA4217F1E"),
                    TransactionDate = DateTime.Now.AddDays(-13),
                    Amount = 6000
                },
                new TransactionEntity()
                {
                    Id = new Guid("0EACCA6E-2B4C-4291-A4D0-3BBA1A8C5813"),
                    AccountNumber = "57580242539941657006",
                    TransactionTypeId = new Guid("F79CA38A-D81E-4C51-9B5F-741626A6BA18"),
                    TransactionDate = DateTime.Now.AddDays(-12),
                    Amount = 0
                },
                new TransactionEntity()
                {
                    Id = new Guid("4F89CC9E-AC64-4F02-B661-D801702C3E00"),
                    AccountNumber = "57580242539941657006",
                    TransactionTypeId = new Guid("4142DE52-7053-478B-804B-B6BFA4217F1E"),
                    TransactionDate = DateTime.Now.AddDays(-12),
                    Amount = 1000
                },
                new TransactionEntity()
                {
                    Id = new Guid("FA36A108-245D-4602-9B97-886354E2971E"),
                    AccountNumber = "57580242539941657006",
                    TransactionTypeId = new Guid("9EC43875-4446-4F52-8DAA-967C2D938C7B"),
                    TransactionDate = DateTime.Now.AddDays(-11),
                    Amount = 21000
                },
                new TransactionEntity()
                {
                    Id = new Guid("346BA847-196A-4952-A169-7D45E48CA3AE"),
                    AccountNumber = "57580242539941657006",
                    TransactionTypeId = new Guid("F79CA38A-D81E-4C51-9B5F-741626A6BA18"),
                    TransactionDate = DateTime.Now.AddDays(-11),
                    Amount = 0
                },
                new TransactionEntity()
                {
                    Id = new Guid("6883834D-A4DF-414C-A8BD-EA658079D4C8"),
                    AccountNumber = "57580242539941657006",
                    TransactionTypeId = new Guid("9EC43875-4446-4F52-8DAA-967C2D938C7B"),
                    TransactionDate = DateTime.Now.AddDays(-10),
                    Amount = 5000
                },
                new TransactionEntity()
                {
                    Id = new Guid("2AC726DD-EF3A-4E78-893D-E142B2D8F3D8"),
                    AccountNumber = "57580242539941657006",
                    TransactionTypeId = new Guid("4142DE52-7053-478B-804B-B6BFA4217F1E"),
                    TransactionDate = DateTime.Now.AddDays(-9),
                    Amount = 10000
                },
                new TransactionEntity()
                {
                    Id = new Guid("5CBE5A42-2914-4A4D-9895-77AD9EE3C409"),
                    AccountNumber = "57580242539941657006",
                    TransactionTypeId = new Guid("F79CA38A-D81E-4C51-9B5F-741626A6BA18"),
                    TransactionDate = DateTime.Now.AddDays(-8),
                    Amount = 0
                },
                //------------------------------------------------------
                //------------------------------------------------------
                //------------------------------------------------------
                //------------------------------------------------------
                //------------------------------------------------------
                new TransactionEntity()
                {
                    Id = new Guid("2CC64CCD-78FA-47DA-A0CC-BCA20B3D803C"),
                    AccountNumber = "68983408175964235159",
                    TransactionTypeId = new Guid("F79CA38A-D81E-4C51-9B5F-741626A6BA18"),
                    TransactionDate = DateTime.Now.AddDays(-20),
                    Amount = 0
                },
                new TransactionEntity()
                {
                    Id = new Guid("7BC2AB9F-B47F-4FB1-AC0B-C905ACCBFEF6"),
                    AccountNumber = "68983408175964235159",
                    TransactionTypeId = new Guid("9EC43875-4446-4F52-8DAA-967C2D938C7B"),
                    TransactionDate = DateTime.Now.AddDays(-19),
                    Amount = 100
                },
                new TransactionEntity()
                {
                    Id = new Guid("8DEF9510-88B2-4EBF-BA85-6B73CD2A2356"),
                    AccountNumber = "68983408175964235159",
                    TransactionTypeId = new Guid("9EC43875-4446-4F52-8DAA-967C2D938C7B"),
                    TransactionDate = DateTime.Now.AddDays(-18),
                    Amount = 150
                },
                new TransactionEntity()
                {
                    Id = new Guid("2BD503E2-692D-4506-8B47-3452822B986B"),
                    AccountNumber = "68983408175964235159",
                    TransactionTypeId = new Guid("F79CA38A-D81E-4C51-9B5F-741626A6BA18"),
                    TransactionDate = DateTime.Now.AddDays(-16),
                    Amount = 0
                },
                new TransactionEntity()
                {
                    Id = new Guid("D8E52A48-70EA-44A2-B8A8-325D5120AED9"),
                    AccountNumber = "68983408175964235159",
                    TransactionTypeId = new Guid("4142DE52-7053-478B-804B-B6BFA4217F1E"),
                    TransactionDate = DateTime.Now.AddDays(-15),
                    Amount = 5700
                },
                new TransactionEntity()
                {
                    Id = new Guid("DFC616D7-DD3E-4A79-99B8-FCE3C4AFD480"),
                    AccountNumber = "68983408175964235159",
                    TransactionTypeId = new Guid("F79CA38A-D81E-4C51-9B5F-741626A6BA18"),
                    TransactionDate = DateTime.Now.AddDays(-14),
                    Amount = 0
                },
                new TransactionEntity()
                {
                    Id = new Guid("D7B96D01-FDAF-43F6-97D5-FD0BBA0941DC"),
                    AccountNumber = "68983408175964235159",
                    TransactionTypeId = new Guid("9EC43875-4446-4F52-8DAA-967C2D938C7B"),
                    TransactionDate = DateTime.Now.AddDays(-14),
                    Amount = 100
                },
                new TransactionEntity()
                {
                    Id = new Guid("2D32E29E-D95F-4A34-9498-369C6B0353E5"),
                    AccountNumber = "68983408175964235159",
                    TransactionTypeId = new Guid("9EC43875-4446-4F52-8DAA-967C2D938C7B"),
                    TransactionDate = DateTime.Now.AddDays(-14),
                    Amount = 150
                },
                new TransactionEntity()
                {
                    Id = new Guid("D74F7FA1-FBF4-4516-9CF8-05215487A55A"),
                    AccountNumber = "68983408175964235159",
                    TransactionTypeId = new Guid("9EC43875-4446-4F52-8DAA-967C2D938C7B"),
                    TransactionDate = DateTime.Now.AddDays(-13),
                    Amount = 150
                },
                new TransactionEntity()
                {
                    Id = new Guid("677AE7D1-F93C-412F-B944-0AAAD2580F3A"),
                    AccountNumber = "68983408175964235159",
                    TransactionTypeId = new Guid("4142DE52-7053-478B-804B-B6BFA4217F1E"),
                    TransactionDate = DateTime.Now.AddDays(-13),
                    Amount = 5700
                },
                new TransactionEntity()
                {
                    Id = new Guid("A199AF2C-0D5B-4BDD-B74E-1CEBA5AFD680"),
                    AccountNumber = "68983408175964235159",
                    TransactionTypeId = new Guid("9EC43875-4446-4F52-8DAA-967C2D938C7B"),
                    TransactionDate = DateTime.Now.AddDays(-12),
                    Amount = 100
                },
                new TransactionEntity()
                {
                    Id = new Guid("6A4DA6AC-8CD6-4C53-A96A-AF1525FDDFB0"),
                    AccountNumber = "68983408175964235159",
                    TransactionTypeId = new Guid("9EC43875-4446-4F52-8DAA-967C2D938C7B"),
                    TransactionDate = DateTime.Now.AddDays(-11),
                    Amount = 150
                },
                new TransactionEntity()
                {
                    Id = new Guid("99891C4A-D4B1-4DCA-B865-7AE0B81927CC"),
                    AccountNumber = "68983408175964235159",
                    TransactionTypeId = new Guid("F79CA38A-D81E-4C51-9B5F-741626A6BA18"),
                    TransactionDate = DateTime.Now.AddDays(-11),
                    Amount = 0
                },
                new TransactionEntity()
                {
                    Id = new Guid("05334834-9DA0-48C5-8FAE-406D030E2BBD"),
                    AccountNumber = "68983408175964235159",
                    TransactionTypeId = new Guid("9EC43875-4446-4F52-8DAA-967C2D938C7B"),
                    TransactionDate = DateTime.Now.AddDays(-9),
                    Amount = 150
                },
                new TransactionEntity()
                {
                    Id = new Guid("D0E74669-040D-4F99-8E71-F58DB535803D"),
                    AccountNumber = "68983408175964235159",
                    TransactionTypeId = new Guid("4142DE52-7053-478B-804B-B6BFA4217F1E"),
                    TransactionDate = DateTime.Now.AddDays(-9),
                    Amount = 7000
                },
                new TransactionEntity()
                {
                    Id = new Guid("52945988-3E34-440F-A8CE-ADD7265FEB3F"),
                    AccountNumber = "68983408175964235159",
                    TransactionTypeId = new Guid("4142DE52-7053-478B-804B-B6BFA4217F1E"),
                    TransactionDate = DateTime.Now.AddDays(-8),
                    Amount = 500
                },
                new TransactionEntity()
                {
                    Id = new Guid("F45E00C6-7D24-48D1-9451-8D82D4A33079"),
                    AccountNumber = "68983408175964235159",
                    TransactionTypeId = new Guid("9EC43875-4446-4F52-8DAA-967C2D938C7B"),
                    TransactionDate = DateTime.Now.AddDays(-7),
                    Amount = 150
                },
                new TransactionEntity()
                {
                    Id = new Guid("F53B4C16-6E95-4CB7-B921-18B1E99E6D79"),
                    AccountNumber = "68983408175964235159",
                    TransactionTypeId = new Guid("9EC43875-4446-4F52-8DAA-967C2D938C7B"),
                    TransactionDate = DateTime.Now.AddDays(-6),
                    Amount = 150
                },
                new TransactionEntity()
                {
                    Id = new Guid("F9AE8CED-FE3E-45FE-B871-EDE0D75A2C5F"),
                    AccountNumber = "68983408175964235159",
                    TransactionTypeId = new Guid("F79CA38A-D81E-4C51-9B5F-741626A6BA18"),
                    TransactionDate = DateTime.Now.AddDays(-4),
                    Amount = 0
                },
                new TransactionEntity()
                {
                    Id = new Guid("F4E41662-9661-40A8-93AB-54C921B050B5"),
                    AccountNumber = "68983408175964235159",
                    TransactionTypeId = new Guid("4142DE52-7053-478B-804B-B6BFA4217F1E"),
                    TransactionDate = DateTime.Now.AddDays(-1),
                    Amount = 5700
                }
                );
        }
    }
}
