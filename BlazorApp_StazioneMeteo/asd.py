


def visit_children(node, prev_route = ""):
    print(f"<li><NavLink class=\"nav-link\" href=\"{prev_route+node['route']}\">{node['name']}</NavLink></li>")
    
    # Se il nodo ha figli
    if 'childs' in node and node['childs']:
        print("<ul>")
        # Itera attraverso tutti i figli del nodo
        for child in node['childs']:
            # Stampa il nome e il percorso del figlio corrente
            # Chiamata ricorsiva per visitare i figli del figlio corrente
            visit_children(child, node['route'])
        print("</ul>")
        
data = [
  {
    "name": "Home",
    "route": "/"
  },
  {
    "name": "Informazioni",
    "route": "/info"
  },
  {
    "name": "Rilevazioni",
    "route": "/rilevazioni"
  },
  {
    "name": "Contatti",
    "route": "/contatti"
  },
  {
    "name": "Stazione Meteo",
    "route": "/stazione-meteo",
    "childs": [
      {
        "name": "Esterno",
        "route": "/esterno",
        "childs": [
          {
            "name": "Anemometro",
            "route": "/anemometro"
          },
          {
            "name": "Banderuola",
            "route": "/banderuola"
          },
          {
            "name": "PiCam",
            "route": "/picam"
          },
          {
            "name": "IgrometroeTermometro",
            "route": "/proterigro"
          },
          {
            "name": "Pluviometro",
            "route": "/pluviometro"
          }
        ]
      },
      {
        "name": "Interno",
        "route": "/interno",
        "childs": [
          {
            "name": "Antirimbalzo",
            "route": "/antirimbalzo"
          },
          {
            "name": "Batteria di continuit�",
            "route": "/batteria_cont"
          },
          {
            "name": "PiCam",
            "route": "/picam"
          },
          {
            "name": "Raspberry",
            "route": "/raspberry"
          },
          {
            "name": "Regolatore tensione entrata",
            "route": "/reg_ten_in"
          },
          {
            "name": "Regolatore tensione uscita",
            "route": "/reg_ten_out"
          },
          {
            "name": "UPS",
            "route": "/ups"
          }
        ]
      },
      {
        "name": "Encoders",
        "route": "/encoders",
        "childs": [
          {
            "name": "Encoder assoluto",
            "route": "/encoder_assoluto"
          },
          {
            "name": "Encoderincrementale",
            "route": "/encoder_incrementale"
          }
        ]
      }
    ]
  }
]

for node in data:
    visit_children(node)