import json

with open("correlati.json","r") as f:
    x = json.load(f)

out = "Dictionary<string, string> _link = new Dictionary<string, string>()\n{\n"
for k,v in x.items():
    out += "{" + f"\"{k}\", \""
    for l in v:
        out += f"{l['titolo']}${l['link']};"
    out = out[:-1] + "\"},\n"
out = out[:-1] + "\n};"
print(out)


