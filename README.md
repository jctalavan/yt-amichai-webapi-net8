# REST API Following CLEAN ARCHITECTURE & DDD

En este repositorio vamos a implementar una api web en .net 8 siguiente la lista de reproducción _REST API Following CLEAN ARCHITECTURE & DDD_ que tiene Amichai Mantinband en su canal de Youtube [link](https://www.youtube.com/playlist?list=PLzYkqgWkHPKBcDIP5gzLfASkQyTdy0t4k)

<!-- TOC start (generated with https://github.com/derlin/bitdowntoc) -->

- [REST API Following CLEAN ARCHITECTURE \& DDD](#rest-api-following-clean-architecture--ddd)
  - [1. Setup the project´s structure](#1-setup-the-projects-structure)
    - [Clean Architecture](#clean-architecture)
  - [2. Generating JWT Tokens](#2-generating-jwt-tokens)
    - [JWT Tokens](#jwt-tokens)
    - [Options pattern](#options-pattern)
  - [3. Implementing the repository pattern](#3-implementing-the-repository-pattern)
    - [Debate: Repository pattern, ¿sí o no?](#debate-repository-pattern-sí-o-no)
  - [4. CQRS + Vertical slice architecture](#4-cqrs--vertical-slice-architecture)
    - [CQRS](#cqrs)
    - [Librería MediatR](#librería-mediatr)
    - [Vertical slice architecture](#vertical-slice-architecture)
  - [5. Mapping](#5-mapping)
    - [Librería Mapster](#librería-mapster)
  - [6. Global Error Handling](#6-global-error-handling)
    - [Middleware](#middleware)
    - [Custom filter attribute](#custom-filter-attribute)
    - [Error endpoint](#error-endpoint)
    - [Problem Details RFC Especification](#problem-details-rfc-especification)
      - [Custom Problem Details Factory](#custom-problem-details-factory)

<!-- TOC end -->

<!-- TOC --><a name="1-setup-the-projects-structure"></a>

## 1. Setup the project´s structure

### Clean Architecture

<!-- TOC --><a name="2-generating-jwt-tokens"></a>

## 2. Generating JWT Tokens

### JWT Tokens

Página de utilidad: <https://jwt.io/>

### Options pattern

<!-- TOC --><a name="3-implementing-the-repository-pattern"></a>

## 3. Implementing the repository pattern

### Debate: Repository pattern, ¿sí o no?

<!-- TOC --><a name="4-cqrs-vertical-slice-architecture"></a>

## 4. CQRS + Vertical slice architecture

### CQRS

### Librería MediatR

MediatR is a library that simplifies communication between various components within an application. It achieves this by following the Mediator pattern, where individual components, or “mediators,” don’t communicate directly with each other but instead send messages to a mediator that handles the distribution of these messages. This separation of concerns promotes modularity and testability, as each component only needs to know about the mediator and the messages it sends, without needing to know the details of the other components.

*Respecto al video de Amichai, en .net 8 se puede utilizar una versión actualizada del paquete Mediatr en la cual la DI se hace de forma diferente y ya no es necesario utilizar un segundo paquete para hacer la DI. En el [siguiente artículo](https://medium.com/@saisiva249/upgrading-mediatr-from-version-12-to-12-in-net-core-9dc7d59b464) podemos encontrar más información acerca de los cambios introducidos en la versión 12 del paquete Mediatr*

### Vertical slice architecture

<!-- TOC --><a name="5-mapping"></a>

## 5. Mapping

### Librería Mapster

Librería alternativa a Automapper, hasta 4 veces más rápida que ésta.

Muchas personas defienden que no se deben usar librerías para hacer el mapeo entre objetos sino que dichos mapeos deben ser manuales. Sus principales argumentos son reducir la complejidad que tiene configurar estos sistemas, reducir los errores y, sobre todo, temas de performance pues al final estas librerías se apoyan en la reflexión.

## 6. Global Error Handling

Para evitar que cuando se produce un error en la aplicación al usuario final le llegue un mensaje muy feo con todo el stacktrace de la excepción, tenemos varias alternativas.

### Middleware

### Custom filter attribute

### Error endpoint

### Problem Details RFC Especification

En esta [RFC](https://datatracker.ietf.org/doc/html/rfc7807) se detalla el objeto problem details que se debe utilizar para notificar de un error en una web api.

#### Custom Problem Details Factory
