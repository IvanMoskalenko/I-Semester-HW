echo 'Report compilation is started.'
cd data
echo 'Figures generation is started.'
python3 main.py
echo 'Figures generation is finished.'
cd ../

echo 'PDF generation is started.'
echo 'First step.'
pdflatex report.tex
echo 'Bibliography generation.'
bibtex report
echo 'Second step.'
pdflatex report.tex
pdflatex report.tex
echo 'Report compilation is finished successfully.'