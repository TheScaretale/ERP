This repository is the ERP i'm building in C#

Currently it has:
  Scan files to look for .XML's that are in accordance to the Brazilian NFe guidelines.
  Search them for CNPJ, Date, who emitted and categorize it accordingly to the user typed CNPJ, if it matches then it's "Nota Própria", otherwise, "Nota Terceiros".
  Sorts those .XML into folders sperating them firstly by Year, then Month-Year, and copy the respective NFe's to their respective folder according to their date.
To do:
  Rename them using their ID.


Other screens to do:
  Login.
  Orders.
  Logistics.
  Accounting.
