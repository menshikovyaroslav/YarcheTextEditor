# YarcheTextEditor
It's a TextEditor for a list of similar strings. For example, for logs.
You can:

1. delete strings with certain word.
example: 
      1. aaa
      2. bbb
      3. ccc
if we delete with word 'aa', we will get a following result:
      1. bbb
      2. ccc
      
2. delete strings without certain word.
example:
      1. aaa
      2. bbb
      3. ccc
if we delete with word 'aa', we will get a following result:
      1. aaa
      
3. Take statistics on occurrences.
example:
      1. aaa
      2. bbb
      3. aaa
      3. ccc
result:
      1. aaa=2
      2. bbb=1
      3. ccc=1
