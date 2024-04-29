import json

with open("correlati.json","r") as f:
    x = json.load(f)

out = ""
for k,v in x.items():
    out += f"{k}: \n\t"
    for l in v:
        out += f"{l['titolo']}${l['link']};"
    out = out[:-1] +"\n"
print(out)


