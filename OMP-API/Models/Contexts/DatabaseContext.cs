using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OMP_API.Models;

namespace OMP_API.Models.Contexts;

public partial class DatabaseContext : IdentityDbContext<IdentityUser>
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ContractType> ContractTypes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DebitNote> DebitNotes { get; set; }

    public virtual DbSet<Error> Errors { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupMessage> GroupMessages { get; set; }

    public virtual DbSet<GroupsUser> GroupsUsers { get; set; }

    public virtual DbSet<ImageInput> ImageInputs { get; set; }

    public virtual DbSet<InvoiceCost> InvoiceCosts { get; set; }

    public virtual DbSet<InvoiceIncome> InvoiceIncomes { get; set; }

    public virtual DbSet<InvoiceTaxRate> InvoiceTaxRates { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationsSubscriber> NotificationsSubscribers { get; set; }

    public virtual DbSet<Payroll> Payrolls { get; set; }

    public virtual DbSet<PayrollTaxRate> PayrollTaxRates { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<PrivateMessage> PrivateMessages { get; set; }

    public virtual DbSet<ReccuringCostInvoice> ReccuringCostInvoices { get; set; }

    public virtual DbSet<ReccuringIncomeInvoice> ReccuringIncomeInvoices { get; set; }

    public virtual DbSet<SpecialGroup> SpecialGroups { get; set; }

    public virtual DbSet<SpecialGroupsTicket> SpecialGroupsTickets { get; set; }

    public virtual DbSet<SpecialGroupsUser> SpecialGroupsUsers { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TextInput> TextInputs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<CustomerModule> CustomerModules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MILOX\\SQLEXPRESS;User ID=MILOX\\milox;Database=OrganizationManagementAppDatabase;TrustServerCertificate=True;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<ContractType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contract__3213E83F3C20CDCF");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.ContractTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ContractT__custo__0E240DFC");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Country__3213E83FAFE6F665");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Currenci__3213E83FD1F38041");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3213E83F35E24FBE");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<DebitNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DebitNot__3213E83FA5ACCDF3");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CurrencyNavigation).WithMany(p => p.DebitNotes).HasConstraintName("FK__DebitNote__curre__2AC04CAA");

            entity.HasOne(d => d.Customer).WithMany(p => p.DebitNotes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DebitNote__custo__2BB470E3");
        });

        modelBuilder.Entity<Error>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Errors__3213E83F89403E77");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.Errors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Errors__customer__31A25463");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Groups__3213E83F53CA99A1");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.Groups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Groups__customer__4D4A6ED8");
        });

        modelBuilder.Entity<GroupMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GroupMes__3213E83FDCCEBE82");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupMessages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GroupMess__group__68F2894D");

            entity.HasOne(d => d.User).WithMany(p => p.GroupMessages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GroupMess__userI__67FE6514");
        });

        modelBuilder.Entity<GroupsUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GroupsUs__3213E83FF1D1464B");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupsUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GroupsUse__group__6339AFF7");

            entity.HasOne(d => d.User).WithMany(p => p.GroupsUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GroupsUse__userI__62458BBE");
        });

        modelBuilder.Entity<ImageInput>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ImageInp__3213E83F78F8C9D2");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<InvoiceCost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceC__3213E83F310AB2C4");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Currency).WithMany(p => p.InvoiceCosts).HasConstraintName("FK__InvoiceCo__curre__17AD7836");

            entity.HasOne(d => d.Customer).WithMany(p => p.InvoiceCosts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InvoiceCo__custo__16B953FD");

            entity.HasOne(d => d.VatTaxNavigation).WithMany(p => p.InvoiceCosts).HasConstraintName("FK__InvoiceCo__vatTa__18A19C6F");
        });

        modelBuilder.Entity<InvoiceIncome>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceI__3213E83FDCD6D769");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Currency).WithMany(p => p.InvoiceIncomes).HasConstraintName("FK__InvoiceIn__curre__1E5A75C5");

            entity.HasOne(d => d.Customer).WithMany(p => p.InvoiceIncomes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InvoiceIn__custo__1D66518C");

            entity.HasOne(d => d.VatTaxNavigation).WithMany(p => p.InvoiceIncomes).HasConstraintName("FK__InvoiceIn__vatTa__1F4E99FE");
        });

        modelBuilder.Entity<InvoiceTaxRate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceT__3213E83F287EAB76");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.InvoiceTaxRates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InvoiceTa__custo__049AA3C2");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3213E83F27B0DAA5");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__userI__58BC2184");
        });

        modelBuilder.Entity<NotificationsSubscriber>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3213E83F329ED79A");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.NotificationsSubscribers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__userI__5D80D6A1");
        });

        modelBuilder.Entity<Payroll>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payroll__3213E83FCDBD170F");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.ContractTypeNavigation).WithMany(p => p.Payrolls)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payroll__contrac__25FB978D");

            entity.HasOne(d => d.Currency).WithMany(p => p.Payrolls).HasConstraintName("FK__Payroll__currenc__25077354");

            entity.HasOne(d => d.Customer).WithMany(p => p.Payrolls)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payroll__custome__24134F1B");
        });

        modelBuilder.Entity<PayrollTaxRate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PayrollT__3213E83FDB6ED523");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.PayrollTaxRates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PayrollTa__custo__095F58DF");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Position__3213E83F16476757");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.Positions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Positions__custo__3E082B48");
        });

        modelBuilder.Entity<PrivateMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PrivateM__3213E83F3BE648B5");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.UserRecipient).WithMany(p => p.PrivateMessageUserRecipients)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PrivateMe__userR__6EAB62A3");

            entity.HasOne(d => d.UserSender).WithMany(p => p.PrivateMessageUserSenders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PrivateMe__userS__6DB73E6A");
        });

        modelBuilder.Entity<ReccuringCostInvoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reccurin__3213E83FF40254C6");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Invoice).WithMany(p => p.ReccuringCostInvoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reccuring__invoi__30792600");
        });

        modelBuilder.Entity<ReccuringIncomeInvoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reccurin__3213E83F89099AD5");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Invoice).WithMany(p => p.ReccuringIncomeInvoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reccuring__invoi__353DDB1D");
        });

        modelBuilder.Entity<SpecialGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SpecialG__3213E83F54E2EB48");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.SpecialGroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SpecialGr__custo__737017C0");
        });

        modelBuilder.Entity<SpecialGroupsTicket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SpecialG__3213E83F6FF0DB49");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.SpecialGroup).WithMany(p => p.SpecialGroupsTickets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SpecialGr__speci__7FD5EEA5");

            entity.HasOne(d => d.User).WithMany(p => p.SpecialGroupsTickets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SpecialGr__userI__7EE1CA6C");
        });

        modelBuilder.Entity<SpecialGroupsUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SpecialG__3213E83F7696AC27");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.SpecialGroupsUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SpecialGr__custo__7834CCDD");

            entity.HasOne(d => d.SpecialGroup).WithMany(p => p.SpecialGroupsUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SpecialGr__speci__7928F116");

            entity.HasOne(d => d.User).WithMany(p => p.SpecialGroupsUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SpecialGr__userI__7A1D154F");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tasks__3213E83F964422DE");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.TaskRecipientNavigation).WithMany(p => p.Tasks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tasks__TaskRecip__520F23F5");

            entity.HasOne(d => d.TaskSenderNavigation).WithMany(p => p.Tasks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tasks__TaskSende__5303482E");
        });

        modelBuilder.Entity<TextInput>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TextInpu__3213E83F13DC09AD");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F4499240F");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Country).WithMany(p => p.Users).HasConstraintName("FK__Users__countryId__47919582");

            entity.HasOne(d => d.Customer).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__customerI__469D7149");

            entity.HasOne(d => d.Position).WithMany(p => p.Users).HasConstraintName("FK__Users__positionI__4885B9BB");

            entity.HasOne<IdentityUser>().WithOne().HasForeignKey<User>(u => u.IdentityUserId).HasConstraintName("FK__Users__IdentityUser");
        });

        modelBuilder.Entity<CustomerModule>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.Customer)
                .WithMany(c => c.CustomerModules)
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Module)
                .WithMany(m => m.CustomerModules)
                .HasForeignKey(e => e.ModuleId);
        });

        OnModelCreatingPartial(modelBuilder);

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
