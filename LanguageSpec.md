# Leo Lang Specification #

## Core Concepts ##
- The Core Concept of Leo Lang is that you dont must use Types. It will be full Type inference implemented.
- LeoLang adds syntactic sugar that c# doesnt have.
- LeoLang has no concept that all values are default to null, if not initialized. You must initialize it or make it nullable
- ValueTypes has only Members and operators.
- OpenSource. You could open Issues with Ideas and if it will be accepted it will be integrated. Or you can make PullRequests. But All will only accepted if the Community has discussed this.
- You can use inline il to use new instructions that the Compiler doesnt support.
- The Compiler does not prohibit you. You can use Pointers, if you want. Without unsafe keyword. 
- The Optimization Pipeline is full controlled by the developer. You can allow/disallow any Optimazation
- LeoLang can use Transactional Memory

## Accesibility ##
- LeoLang introduces a new Accesibility concept. Some old like (public, private) and new Modifiers like (shared).
- By default, Locals are immutable. You can change the behavior with the mutable keyword

### shared modifier ###
The shared modifier creates a wrapper for fields, methods and events for shared memory with memory mapped files.

## Extensibility ##
- LeoLang is not a Language Orientated Language. So you cant add new Syntax Elements to it. But you can write Extensions to the CompilerPipeline. So you can add Optimisations that the Compiler currently has not implemented.
But you can easily define new Operators and with a CompilerPlugin you could introduce new syntactic sugar with existing syntax elements.
- LeoLang will introduce a special CodeBlock. That will not parsed by LeoLang itself. It can be used for custom Language Parser for Example to build XML Dom or Json Objects.
- You can make a custom Allocator for Memory for example store large Objects on disc.
- You can overload the default operator, to prevent null values
- You can define Macros that will be expanded at compiletime

## Planned Syntaxctic Sugar ##
- Discriminated Unions
- Unions for Memory like in c
- String based Enums -> generate a struct with all boilerplate code
- async/await -> but the heuristic should be so smart, that you dont need to use the keyword async
- in the If Statement you can check if the value of a nullable type is true by simply use the name of the symbol. 
- In LeoLang you can simply add two IEnumerable containers together or apply other operators
- You can check if a value is in a specific range.
- Automatic fluid API generation
  
