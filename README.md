# Sistema de Gestão de Pizzaria - .NET 8 (MVP)

Ecossistema completo desenvolvido em C# / .NET 9 cobrindo o ciclo operacional de uma pizzaria: do pedido via aplicativo até a esteira de preparo na cozinha e o gerenciamento de pedidos.

---

### Módulos do Sistema

1. **Core API (ASP.NET Core 9)**
   - Endpoints RESTful para autenticação, catálogo de produtos e fluxo de pedidos.
   - Comunicação em tempo real via **SignalR** para disparo de eventos para o monitor da cozinha.

2. **Aplicativo Mobile (.NET MAUI)**
   - Interface cross-platform em XAML com padrão **MVVM** para visualização do cardápio e envio de pedidos.

3. **Aplicativo Desktop Operacional (WinForms)**
   - Monitor de cozinha (KDS - Kitchen Display System) para recepção e alteração do status dos pedidos em tempo real.

4. **Persistência de Dados (SQL Server)**
   - Mapeamento e persistência das entidades do sistema utilizando **Entity Framework Core 9**.
