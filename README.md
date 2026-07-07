# 🏢 HubSpace

O **HubSpace** é uma plataforma web monolítica voltada para a gestão e reserva de posições de trabalho (hotdesking) e salas de reunião em ambientes de coworking. O projeto foi estruturado com foco em alta coesão e baixo acoplamento, isolando as regras de negócio das camadas de apresentação e persistência.

---

## 🛠️ Stack Tecnológica

* **Framework Principal:** .NET Framework 4.8 / ASP.NET MVC 5
* **Persistência de Dados:** Entity Framework 6 (Abordagem Code-First com Migrations)
* **Banco de Dados:** Microsoft SQL Server (LocalDB)
* **Renderização:** Razor Engine (Server-Side Rendering - SSR)
* **IDE Utilizada:** JetBrains Rider

---

## 📐 Arquitetura e Organização do Projeto

A solução foi desenhada dividindo as responsabilidades em camadas claras para garantir a manutenibilidade do ecossistema:

```text
HubSpace.Web
├── 📁 Controllers        # Camada de Orquestração (Recebe requisições HTTP)
├── 📁 ViewModels         # Blindagem e formatação de dados para a camada de apresentação
├── 📁 Services           # Camada Gerenciadora (Centraliza as Regras de Negócio do sistema)
├── 📁 Repositories       # Camada de Repositório (Abstração e isolamento do acesso ao banco de dados)
├── 📁 Models             # Entidades de Domínio e Contexto do Entity Framework (Mapeamento Relacional)
├── 📁 App_Start          # Configurações globais (Rotas, Filtros, Bundles)
└── 📄 Global.asax        # Ciclo de vida da aplicação e bootstrap do banco de dados
