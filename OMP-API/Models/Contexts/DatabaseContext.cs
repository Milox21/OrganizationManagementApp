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

    public virtual DbSet<Admin> Admins { get; set; }

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MILOX\\SQLEXPRESS;User ID=MILOX\\milox;Database=OrganizationManagementAppDatabase;TrustServerCertificate=True;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admins__3213E83FFADA5D77");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<ContractType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contract__3213E83F5815878A");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.ContractTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ContractT__custo__4A4E069C");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Country__3213E83F881D31EE");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Currenci__3213E83F918EF608");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3213E83FBA8D94FA");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<DebitNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DebitNot__3213E83F09677558");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.DebitNotes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DebitNote__custo__603D47BB");
        });

        modelBuilder.Entity<Error>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Errors__3213E83F74876A49");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.Errors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Errors__customer__6EC0713C");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Groups__3213E83FD3834658");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.Groups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Groups__customer__05A3D694");
        });

        modelBuilder.Entity<GroupMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GroupMes__3213E83FF4260B8C");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupMessages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GroupMess__group__214BF109");

            entity.HasOne(d => d.User).WithMany(p => p.GroupMessages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GroupMess__userI__2057CCD0");
        });

        modelBuilder.Entity<GroupsUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GroupsUs__3213E83F1A74F4EA");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupsUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GroupsUse__group__1B9317B3");

            entity.HasOne(d => d.User).WithMany(p => p.GroupsUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GroupsUse__userI__1A9EF37A");
        });

        modelBuilder.Entity<ImageInput>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ImageInp__3213E83F11FB439D");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<InvoiceCost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceC__3213E83F4730B068");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.InvoiceCosts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InvoiceCo__custo__4F12BBB9");

            entity.HasOne(d => d.VatTaxNavigation).WithMany(p => p.InvoiceCosts).HasConstraintName("FK__InvoiceCo__vatTa__5006DFF2");
        });

        modelBuilder.Entity<InvoiceIncome>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceI__3213E83F6F4DA711");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.InvoiceIncomes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InvoiceIn__custo__54CB950F");

            entity.HasOne(d => d.VatTaxNavigation).WithMany(p => p.InvoiceIncomes).HasConstraintName("FK__InvoiceIn__vatTa__55BFB948");
        });

        modelBuilder.Entity<InvoiceTaxRate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceT__3213E83FF2C8D260");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.InvoiceTaxRates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InvoiceTa__custo__40C49C62");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3213E83F1C8EAB56");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__userI__11158940");
        });

        modelBuilder.Entity<NotificationsSubscriber>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3213E83F5BD0CE61");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.NotificationsSubscribers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__userI__15DA3E5D");
        });

        modelBuilder.Entity<Payroll>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payroll__3213E83F7EDFC64D");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.ContractTypeNavigation).WithMany(p => p.Payrolls)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payroll__contrac__5B78929E");

            entity.HasOne(d => d.Customer).WithMany(p => p.Payrolls)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payroll__custome__5A846E65");
        });

        modelBuilder.Entity<PayrollTaxRate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PayrollT__3213E83F578F27D2");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.PayrollTaxRates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PayrollTa__custo__4589517F");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Position__3213E83FFD67D6A3");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.Positions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Positions__custo__7B264821");
        });

        modelBuilder.Entity<PrivateMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PrivateM__3213E83F60C30931");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.UserRecipient).WithMany(p => p.PrivateMessageUserRecipients)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PrivateMe__userR__2704CA5F");

            entity.HasOne(d => d.UserSender).WithMany(p => p.PrivateMessageUserSenders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PrivateMe__userS__2610A626");
        });

        modelBuilder.Entity<ReccuringCostInvoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reccurin__3213E83F4D6AC24D");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.ReccuringCostInvoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reccuring__custo__6501FCD8");

            entity.HasOne(d => d.Invoice).WithMany(p => p.ReccuringCostInvoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reccuring__invoi__65F62111");
        });

        modelBuilder.Entity<ReccuringIncomeInvoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reccurin__3213E83FA29DD903");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.ReccuringIncomeInvoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reccuring__custo__6ABAD62E");

            entity.HasOne(d => d.Invoice).WithMany(p => p.ReccuringIncomeInvoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reccuring__invoi__6BAEFA67");
        });

        modelBuilder.Entity<SpecialGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SpecialG__3213E83FF1856CEF");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.SpecialGroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SpecialGr__custo__2BC97F7C");
        });

        modelBuilder.Entity<SpecialGroupsTicket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SpecialG__3213E83F03BD1DB8");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.SpecialGroup).WithMany(p => p.SpecialGroupsTickets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SpecialGr__speci__382F5661");

            entity.HasOne(d => d.User).WithMany(p => p.SpecialGroupsTickets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SpecialGr__userI__373B3228");
        });

        modelBuilder.Entity<SpecialGroupsUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SpecialG__3213E83F9A09927F");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.SpecialGroupsUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SpecialGr__custo__308E3499");

            entity.HasOne(d => d.SpecialGroup).WithMany(p => p.SpecialGroupsUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SpecialGr__speci__318258D2");

            entity.HasOne(d => d.User).WithMany(p => p.SpecialGroupsUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SpecialGr__userI__32767D0B");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tasks__3213E83F81C74467");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.TaskRecipientNavigation).WithMany(p => p.Tasks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tasks__TaskRecip__0A688BB1");

            entity.HasOne(d => d.TaskSenderNavigation).WithMany(p => p.Tasks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tasks__TaskSende__0B5CAFEA");
        });

        modelBuilder.Entity<TextInput>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TextInpu__3213E83F91C0D28B");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83FD3C01ED7");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.Users).HasConstraintName("FK__Users__customerI__7FEAFD3E");

            entity.HasOne(d => d.Position).WithMany(p => p.Users).HasConstraintName("FK__Users__positionI__00DF2177");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
