# 📄 IDEIA DO PROJETO - CP2 - ADVANCED BUSINESS DEVELOPMENT WITH .NET

Este documento apresenta a proposta do grupo para o projeto de CP2, baseado no desafio da Mottu.

---

## 👥 INTEGRANTES DO GRUPO

- **RM555213** - Luiz Eduardo Da Silva Pinto  
- **RM556460** - Eduardo Augusto Pelegrino Einsfeldt  
- **RM557183** - Murillo Ari Ferreira Sant'Anna  

---

## 📘 TÍTULO DO PROJETO

**Sistema de Gestão e Organização de Pátios**

---

## 🎯 PROBLEMA A SER RESOLVIDO

A Mottu enfrenta dificuldades para manter seus pátios organizados, especialmente na alocação e localização das motos.  
O processo atual é manual e desorganizado, resultando em:

- Perda de tempo para localizar motos
- Ocupação ineficiente dos espaços
- Possível superlotação
- Impacto direto na agilidade operacional

---

## 💡 SOLUÇÃO PROPOSTA

Desenvolveremos um sistema focado na **gestão visual e organizacional do espaço físico dos pátios** da Mottu.

### O que ele faz?
- Permite cadastrar, visualizar e gerenciar motos dentro do layout do pátio.

### Como ajuda a resolver o problema?
- Otimiza a ocupação do espaço
- Facilita a localização das motos
- Gera relatórios sobre uso de vagas
- Evita superlotação

### Funcionalidades principais:
- Cadastro e atualização de motos
- Mapeamento visual do pátio com posições ocupadas
- Relatórios de ocupação
- Alertas de capacidade máxima
- Filtros por status da moto (ativa, manutenção, retirada)

---

## 📐 ENTIDADES PRINCIPAIS

- **Moto**: placa, modelo, status, posição no pátio  
- **Pátio**: nome da unidade, capacidade total, vagas disponíveis  
- **Vaga**: código da vaga, status, posição no grid  
- **Histórico**: entradas, saídas e trocas de posição das motos

---

## 🛠 TECNOLOGIAS E ESTRUTURA

- .NET 8  
- Entity Framework Core com Oracle  
- Swagger para documentação da API  
- Clean Architecture  
- Padrões de projeto: DTOs, MappingConfig, Migrations  

---

## 📌 OBSERVAÇÕES FINAIS

Nosso objetivo é oferecer uma solução moderna e escalável que melhore a organização dos pátios da Mottu, reduza o tempo de operação e aumente o controle sobre as motos.  
Futuramente, o sistema pode ser expandido com integração a dispositivos IoT, rastreamento GPS e aplicações móveis para operações em campo.

---
