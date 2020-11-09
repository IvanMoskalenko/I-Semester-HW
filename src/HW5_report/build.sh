echo 'Report compilation is started.'
cd data
echo 'Figures generation is started.'
python3 main.py
echo 'Figures generation is finished.'
cd ../


echo 'PDF generation is started.'
pdflatex report.tex
pdflatex report.tex
echo 'Report compilation is finished successfully.'