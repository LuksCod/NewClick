using NewClick.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NewClick.API.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedUsuarioPadrao(builder);
        SeedCategoriaPadrao(builder);
        SeedProdutoPadrao(builder);
    }

    private static void SeedUsuarioPadrao(ModelBuilder builder)
    {
        #region Populate Roles - Perfis de Usuário
        List<IdentityRole> roles =
        [
            new IdentityRole() {
               Id = "0b44ca04-f6b0-4a8f-a953-1f2330d30894",
               Name = "Administrador",
               NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole() {
               Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
               Name = "Cliente",
               NormalizedName = "CLIENTE"
            },
        ];
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Populate Usuário
        List<Usuario> usuarios = [
            new Usuario(){
                Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                Email = "lucas.theodosio@email.com",
                NormalizedEmail = "LUCAS.THEODOSIO@EMAIL.COM",
                UserName = "lucas.theodosio@email.com",
                NormalizedUserName = "LUCAS.THEODOSIO@EMAIL.COM",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Nome = "Lucas Theodosio",
                DataNascimento = DateTime.Parse("04/01/2001"),
                Foto = "/img/usuarios/avatar.png"
            }
        ];
        foreach (var user in usuarios)
        {
            PasswordHasher<Usuario> pass = new();
            user.PasswordHash = pass.HashPassword(user, "123456");
        }
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Populate UserRole - Usuário com Perfil
        List<IdentityUserRole<string>> userRoles =
        [
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[0].Id
            }
        ];
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }

    private static void SeedCategoriaPadrao(ModelBuilder builder)
    {
        List<Categoria> categorias = new()
        {
            new Categoria { Id = 1, Nome = "Headset" },
            new Categoria { Id = 2, Nome = "Monitor" },
            new Categoria { Id = 3, Nome = "Mouse" },
            new Categoria { Id = 4, Nome = "Teclado" },
        };
        builder.Entity<Categoria>().HasData(categorias);
    }

    private static void SeedProdutoPadrao(ModelBuilder builder)
    {
        List<Produto> produtos = new()
        {
            new Produto { Id = 1, CategoriaId = 1, Nome = "Headset Gamer HyperX Cloud Stinger 2 Core.", Descricao = "O Headset Gamer HyperX Cloud Stinger 2 Core é um headset de entrada com fio que se destaca pelo seu conforto leve, áudio imersivo com graves aprimorados e recursos essenciais, como o microfone com função flip-to-mute. É uma opção acessível e considerada honesta pelo seu custo-benefício, compatível com múltiplas plataformas (PC, PlayStation, Xbox, Switch).", ValorCusto = 450.00m, ValorVenda = 699.00m, Qtde = 10, Destaque = true, Foto = "/img/produtos/fone.1.png" },
            new Produto { Id = 2, CategoriaId = 1, Nome = "Headset JBL Quantum 810.", Descricao = "O Headset JBL Quantum 810 é um modelo premium sem fio que oferece áudio de alta fidelidade com certificação Hi-Res, tecnologia QuantumSOUND Signature e som espacial JBL QuantumSURROUND e DTS Headphone:X 2.0 para uma imersão superior. Possui conectividade dupla via dongle 2.4 GHz e Bluetooth 5.2, bateria de longa duração e microfone boom com cancelamento de eco e ruído, além de função auto on/off e mute.", ValorCusto = 400.00m, ValorVenda = 699.00m, Qtde = 15, Destaque = true, Foto = "/img/produtos/2.png" },
            new Produto { Id = 3, CategoriaId = 2, Nome = "Monitor gamer AOC 24G2U5. ", Descricao = "O Monitor Gamer AOC 24G2U5 é um modelo Full HD de 23,8 polegadas ideal para jogos competitivos, oferecendo uma taxa de atualização de 75 Hz e tempo de resposta de 1 ms para imagens fluidas e sem rastros. Utiliza painel IPS, que garante cores vibrantes e ângulos de visão amplos, e possui tecnologia FreeSync Premium para eliminar rasgos e gagueira na tela. Conta com design sem bordas, ajuste ergonômico de altura e conectividade versátil.", ValorCusto = 350.00m, ValorVenda = 529.00m, Qtde = 20 },
            new Produto { Id = 4, CategoriaId = 2, Nome = "Monitor Samsung Essential S3 de 32 polegadas.", Descricao = "O Monitor Samsung Essential S3 de 32 polegadas (M7 ou similar) é um monitor versátil e elegante, focado em produtividade e entretenimento. Destaca-se pelo seu tamanho generoso, resolução Full HD ou superior (dependendo do modelo exato, geralmente 4K na linha M7 Smart), e recursos como painel VA para pretos profundos e bom contraste. Possui design minimalista e bordas finas, ideal para multitarefas ou consumo de mídia.", ValorCusto = 320.00m, ValorVenda = 479.00m, Qtde = 12 },
            new Produto { Id = 5, CategoriaId = 3, Nome = "Mouse gamer MSI Clutch GM30.", Descricao = "O Mouse Gamer MSI Clutch GM30 é um mouse com fio que se caracteriza pelo seu design simétrico e ergonômico, adequado para diversos estilos de pegada. Possui sensor óptico PixArt PAW-3327 com até 6200 DPI, switches duráveis da OMRON (com mais de 20 milhões de cliques) e iluminação RGB Mystic Light personalizável. É uma opção sólida e confiável para jogadores que buscam um periférico com boa precisão e construção robusta.", ValorCusto = 420.00m, ValorVenda = 699.00m, Qtde = 8 },
            new Produto { Id = 6, CategoriaId = 3, Nome = "Mouse Gamer Sem Fio Logitech G PRO X Superlight", Descricao = "O Mouse Gamer Sem Fio Logitech G PRO X Superlight é um periférico ultraleve, pesando menos de 63 gramas, projetado para o mais alto nível de jogo competitivo. Utiliza a tecnologia sem fio Lightspeed para uma conexão estável e de latência extremamente baixa. Equipado com o sensor HERO 25K de alta precisão e switches mecânicos, é a escolha de muitos profissionais de eSports que buscam desempenho máximo e peso mínimo.", ValorCusto = 420.00m, ValorVenda = 699.00m, Qtde = 8 },
            new Produto { Id = 7, CategoriaId = 4, Nome = "Teclado Gamer Redragon Centaur K506.", Descricao = "O Teclado Gamer Redragon Centaur K506 é um teclado de membrana de baixo custo, que oferece uma experiência tátil semelhante aos teclados mecânicos. Possui design robusto, iluminação LED RGB com diversos modos de luz, e teclas multimídia dedicadas para controle de áudio. É uma opção popular para quem está começando no mundo dos jogos e busca um teclado com visual gamer e funcionalidades básicas, como anti-ghosting em algumas teclas.", ValorCusto = 420.00m, ValorVenda = 699.00m, Qtde = 8 },
            new Produto { Id = 8, CategoriaId = 4, Nome = "Teclado e mouse sem fio da Logitech.", Descricao = "O conjunto de teclado e mouse sem fio da Logitech (geralmente modelos como MK270, MK345 ou similares) é uma solução prática e confiável para uso diário em escritório ou casa. Oferece conectividade sem fio estável de 2.4 GHz com um único receptor USB (Unifying), design confortável e bateria de longa duração. São periféricos plug-and-play, focados em simplicidade, eficiência e organização do espaço de trabalho.", ValorCusto = 420.00m, ValorVenda = 699.00m, Qtde = 8 },
        };
        builder.Entity<Produto>().HasData(produtos);
    }

}