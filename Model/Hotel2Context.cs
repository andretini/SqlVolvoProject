using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Projeto_SQL.Model;

public partial class Hotel2Context : DbContext
{
    public Hotel2Context()
    {
    }

    public Hotel2Context(DbContextOptions<Hotel2Context> options)
        : base(options)
    {
    }

    public  DbSet<Cliente> Clientes { get; set; }

    public  DbSet<Filial> Filials { get; set; }

    public  DbSet<Funcionario> Funcionarios { get; set; }

    public  DbSet<Gasto> Gastos { get; set; }

    public  DbSet<Produto> Produtos { get; set; }

    public  DbSet<Quarto> Quartos { get; set; }

    public  DbSet<Reserva> Reservas { get; set; }

    public  DbSet<ServicosLavanderium> ServicosLavanderia { get; set; }

    public  DbSet<TipoFuncionario> TipoFuncionarios { get; set; }

    public  DbSet<TipoQuarto> TipoQuartos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(@"SERVER=.\;Database=HOTEL2;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__E005FBFF0D823FF1");

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Endereco)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nacionalidade)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NomeCliente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nome_Cliente");
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Filial>(entity =>
        {
            entity.HasKey(e => e.IdFilial).HasName("PK__Filial__942DC1C52228E744");

            entity.ToTable("Filial");

            entity.Property(e => e.IdFilial).HasColumnName("ID_Filial");
            entity.Property(e => e.Endereco)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.IdFuncionario).HasName("PK__Funciona__0AE977B9AE9EBB1A");

            entity.Property(e => e.IdFuncionario).HasColumnName("ID_Funcionario");
            entity.Property(e => e.FkFilialIdFilial).HasColumnName("fk_Filial_ID_Filial");
            entity.Property(e => e.FkTipoFuncionarioIdProficao).HasColumnName("fk_Tipo_Funcionario_ID_Proficao");
            entity.Property(e => e.NomeFuncionario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nome_Funcionario");

            entity.HasOne(d => d.FkFilialIdFilialNavigation).WithMany(p => p.Funcionarios)
                .HasForeignKey(d => d.FkFilialIdFilial)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Funcionarios_2");

            entity.HasOne(d => d.FkTipoFuncionarioIdProficaoNavigation).WithMany(p => p.Funcionarios)
                .HasForeignKey(d => d.FkTipoFuncionarioIdProficao)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Funcionarios_3");
        });

        modelBuilder.Entity<Gasto>(entity =>
        {
            entity.HasKey(e => e.IdGasto).HasName("PK__Gastos__57709B7A53EAF1EB");

            entity.Property(e => e.IdGasto).HasColumnName("ID_Gasto");
            entity.Property(e => e.EntregaQuarto).HasColumnName("Entrega_Quarto");
            entity.Property(e => e.FkProdutosIdProduto).HasColumnName("fk_Produtos_ID_Produto");
            entity.Property(e => e.FkReservaIdReserva).HasColumnName("fk_Reserva_ID_Reserva");
            entity.Property(e => e.FkServicosLavanderiaIdLavagem).HasColumnName("fk_Servicos_Lavanderia_ID_Lavagem");

            entity.HasOne(d => d.FkProdutosIdProdutoNavigation).WithMany(p => p.Gastos)
                .HasForeignKey(d => d.FkProdutosIdProduto)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Gastos_3");

            entity.HasOne(d => d.FkReservaIdReservaNavigation).WithMany(p => p.Gastos)
                .HasForeignKey(d => d.FkReservaIdReserva)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Gastos_2");

            entity.HasOne(d => d.FkServicosLavanderiaIdLavagemNavigation).WithMany(p => p.Gastos)
                .HasForeignKey(d => d.FkServicosLavanderiaIdLavagem)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Gastos_4");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.IdProduto).HasName("PK__Produtos__525292A1D3E493AF");

            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.FkFilialIdFilial).HasColumnName("fk_Filial_ID_Filial");
            entity.Property(e => e.NomeProduto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nome_Produto");
            entity.Property(e => e.ValorProduto).HasColumnName("Valor_Produto");

            entity.HasOne(d => d.FkFilialIdFilialNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.FkFilialIdFilial)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Produtos_2");
        });

        modelBuilder.Entity<Quarto>(entity =>
        {
            entity.HasKey(e => e.IdQuarto).HasName("PK__Quartos__1250700B834D29B5");

            entity.Property(e => e.IdQuarto).HasColumnName("ID_Quarto");
            entity.Property(e => e.FkFilialIdFilial).HasColumnName("fk_Filial_ID_Filial");
            entity.Property(e => e.FkTipoQuartoIdPlanta).HasColumnName("fk_Tipo_Quarto_ID_Planta");

            entity.HasOne(d => d.FkFilialIdFilialNavigation).WithMany(p => p.Quartos)
                .HasForeignKey(d => d.FkFilialIdFilial)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Quartos_2");

            entity.HasOne(d => d.FkTipoQuartoIdPlantaNavigation).WithMany(p => p.Quartos)
                .HasForeignKey(d => d.FkTipoQuartoIdPlanta)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Quartos_3");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__Reserva__12CAD9F402DC0EDB");

            entity.ToTable("Reserva");

            entity.Property(e => e.IdReserva).HasColumnName("ID_Reserva");
            entity.Property(e => e.DataReserva)
                .HasColumnType("datetime")
                .HasColumnName("Data_Reserva");
            entity.Property(e => e.FkClienteIdCliente).HasColumnName("fk_Cliente_ID_Cliente");
            entity.Property(e => e.FkFilialIdFilial).HasColumnName("fk_Filial_ID_Filial");
            entity.Property(e => e.FkFuncionariosIdFuncionario).HasColumnName("fk_Funcionarios_ID_Funcionario");
            entity.Property(e => e.FkQuartosIdQuarto).HasColumnName("fk_Quartos_ID_Quarto");

            entity.HasOne(d => d.FkClienteIdClienteNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.FkClienteIdCliente)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Reserva_2");

            entity.HasOne(d => d.FkFilialIdFilialNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.FkFilialIdFilial)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Reserva_5");

            entity.HasOne(d => d.FkFuncionariosIdFuncionarioNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.FkFuncionariosIdFuncionario)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Reserva_3");

            entity.HasOne(d => d.FkQuartosIdQuartoNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.FkQuartosIdQuarto)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Reserva_4");
        });

        modelBuilder.Entity<ServicosLavanderium>(entity =>
        {
            entity.HasKey(e => e.IdLavagem).HasName("PK__Servicos__8194C3C37F5A9C68");

            entity.ToTable("Servicos_Lavanderia");

            entity.Property(e => e.IdLavagem).HasColumnName("ID_Lavagem");
            entity.Property(e => e.FkFilialIdFilial).HasColumnName("fk_Filial_ID_Filial");
            entity.Property(e => e.NomeLavagem)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nome_Lavagem");
            entity.Property(e => e.ValorLavagem).HasColumnName("Valor_Lavagem");

            entity.HasOne(d => d.FkFilialIdFilialNavigation).WithMany(p => p.ServicosLavanderia)
                .HasForeignKey(d => d.FkFilialIdFilial)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Servicos_Lavanderia_2");
        });

        modelBuilder.Entity<TipoFuncionario>(entity =>
        {
            entity.HasKey(e => e.IdProficao).HasName("PK__Tipo_Fun__CB6C87D48DD93035");

            entity.ToTable("Tipo_Funcionario");

            entity.Property(e => e.IdProficao).HasColumnName("ID_Proficao");
            entity.Property(e => e.Profissao)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoQuarto>(entity =>
        {
            entity.HasKey(e => e.IdPlanta).HasName("PK__Tipo_Qua__5BE7FB9828A9F50A");

            entity.ToTable("Tipo_Quarto");

            entity.Property(e => e.IdPlanta).HasColumnName("ID_Planta");
            entity.Property(e => e.Descricao)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
