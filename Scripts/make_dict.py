import sys

with open(sys.argv[1]) as f:
    text = f.read()

lines = [x.strip() for x in text.split('\n')]

d = {}
for idx in range(1000):
    for line in lines:
        if line.lower().startswith("// " + str(idx)):
            # Find the next line that does not start with "//"
            declaration_line = None
            for next_line in lines[lines.index(line) + 1:]:
                if not next_line.startswith("//"):
                    declaration_line = next_line
                    break
            else:
                print("No declaration found for line: " + line)
                continue
            
            # print(declaration_line)
            function_name = declaration_line.split(" ")[1].split("(")[0]
            # print(idx, ": ", function_name)
            d[idx] = function_name
            break
    else:
        pass
        # print("Found no entry for " + str(idx))

for k, v in d.items():
    print("{{ {}, \"{}\" }},".format(k, v))
