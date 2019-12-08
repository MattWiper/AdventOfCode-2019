
'''
    ADVENT OF CODE - 2
    
    1XYN - Store the result of X + Y in N
    2XYN - Store the result of X * Y in N
    99   - Exit
'''
def check_noun_verb_output(value, output):
    if value == output:
        return True

def run_program(puzzle_input):
  parsed_input = puzzle_input
  m_pc = 0
  
  while True:
      op_code = parsed_input[m_pc]

      if op_code == 1:
        parsed_input[parsed_input[m_pc + 3]] = parsed_input[parsed_input[m_pc + 1]] + parsed_input[parsed_input[m_pc + 2]]
        m_pc = m_pc + 4
      elif op_code == 2: 
        parsed_input[parsed_input[m_pc + 3]] = parsed_input[parsed_input[m_pc + 1]] * parsed_input[parsed_input[m_pc + 2]]
        m_pc = m_pc + 4
      elif op_code == 99:
        break
      else:
        print("program error. exiting...")
        break

  return parsed_input[0]


if __name__== "__main__":
  puzzle_input = "1,12,12,3,1,1,2,3,1,3,4,3,1,5,0,3,2,9,1,19,1,19,5,23,1,23,5,27,2,27,10,31,1,31,9,35,1,35,5,39,1,6,39,43,2,9,43,47,1,5,47,51,2,6,51,55,1,5,55,59,2,10,59,63,1,63,6,67,2,67,6,71,2,10,71,75,1,6,75,79,2,79,9,83,1,83,5,87,1,87,9,91,1,91,9,95,1,10,95,99,1,99,13,103,2,6,103,107,1,107,5,111,1,6,111,115,1,9,115,119,1,119,9,123,2,123,10,127,1,6,127,131,2,131,13,135,1,13,135,139,1,9,139,143,1,9,143,147,1,147,13,151,1,151,9,155,1,155,13,159,1,6,159,163,1,13,163,167,1,2,167,171,1,171,13,0,99,2,0,14,0"
  parsed_input = list(map(int, puzzle_input.split(",")))
  noun_verb_output = 19690720

  for i in range(0, 99):
      for y in range(0, 99):
          parsed_input[1] = i 
          parsed_input[2] = y
          output = run_program(parsed_input.copy())

          print("Program finished. Output: {}".format(output))

          if check_noun_verb_output(noun_verb_output, output):
              print("Found noun + verb combination that resulted in output == {0}. Noun: {1}. Verb: {2}".format(noun_verb_output, i, y))
