using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;

using System.Windows.Forms;

namespace btGRMain.Grid
{
	public class cutePrinter
	{
		public string dtB;
		public string dtE;
		private DataGrid dataGrid;
		private PrintDocument printDocument;
		private PageSetupDialog pageSetupDialog;
		private PrintPreviewDialog printPreviewDialog;

		private string title="";
  
		int currentPageIndex=0;
		int rowCount=0;
		int pageCount=0;

		int titleSize=20;//�����С
		bool isCustomHeader=false;
  
		//Brush alertBrush=new SolidBrush(Color.Red);

		string[] header=null;//����Զ���������ַ����������Ҫб�߷ָ�������\��ʾ�����磺����#���� ����#ΪsplitChar
		string[] uplineHeader=null;//������������
		int[] upLineHeaderIndex=null;//���е�����index,���û�����о���Ϊ-1��
//		bool isEveryPagePrintHead=true;//�Ƿ�ÿһҳ��Ҫ��ӡ��ͷ��

		public frmDataPrint m_frm=null;
		public bool isEveryPagePrintTitle=false;//�Ƿ�ÿһҳ��Ҫ��ӡ���⡣
		public int headerHeight=45;//�б���߶ȡ�
		public int topMargin=40; //���߾� ��ͷ�����ľ���
		public int cellTopMargin=3;//��Ԫ�񶥱߾�
		public int cellLeftMargin=4;//��Ԫ����߾�
		public char splitChar='#';//��headerҪ��б�߱�ʾ��ʱ��
		public string falseStr="��";//�����������dataGrid���� false,����ת�����ַ���
		public string trueStr="��";//�����������dataGrid���� true,����ת�����ַ���
		public int pageRowCount=7;//ÿҳ����
		public int rowGap = 22;//�и�
		public int colGap = 4;//ÿ�м��
		public int leftMargin = 50;//��߾�
		public Font titleFont=new Font("Arial",20);//��ͷ����
		public Font font = new Font("Arial", 9);//��������
		public Font headerFont = new Font("Arial", 9, FontStyle.Bold);//��������
		public Font footerFont=new Font("Arial",8);//ҳ����ʾҳ��������
		public Font upLineFont=new Font("Arial",9, FontStyle.Bold);//��header��������ʾ��ʱ��������ʾ�����塣
		public Font underLineFont=new Font("Arial",9);//��header��������ʾ��ʱ��������ʾ�����塣
		public Brush brush = new SolidBrush(Color.Black);//��ˢ
		public bool isAutoPageRowCount=true;//�Ƿ��Զ�����������
		public int buttomMargin=120;//�ױ߾�
		public bool needPrintPageIndex=true;//�Ƿ��ӡҳ��ҳ��


		public cutePrinter(DataGrid dataGrid,string title,int titleSize)
		{ 
			try
			{
				this.title=title;
				this.titleSize=titleSize;

				this.dataGrid = dataGrid; 
				printDocument = new PrintDocument();
				printDocument.PrintPage += new PrintPageEventHandler(this.printDocument_PrintPage);

			}
			catch(Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		} 
		public cutePrinter(DataGrid dataGrid,string title)
		{ 

			try
			{
				this.title=title;

				this.dataGrid = dataGrid; 
				printDocument = new PrintDocument();
				printDocument.PrintPage += new PrintPageEventHandler(this.printDocument_PrintPage);
			}
			catch(Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		} 
		public cutePrinter(DataGrid dataGrid)
		{ 
			try
			{
				this.dataGrid = dataGrid; 
				printDocument = new PrintDocument();
				printDocument.PrintPage += new PrintPageEventHandler(this.printDocument_PrintPage);
			}
			catch(Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		} 

		public bool setTowLineHeader(string[] upLineHeader,int[] upLineHeaderIndex)
		{
			try
			{
				this.uplineHeader=upLineHeader;
				this.upLineHeaderIndex=upLineHeaderIndex;
				this.isCustomHeader=true;
				return true;
			}
			catch(Exception e)
			{
				MessageBox.Show(e.ToString());
				return false;
			}
		}
		public bool setHeader(string[] header)
		{
			try
			{
				this.header=header;
				return true;
			}
			catch(Exception e)
			{
				MessageBox.Show(e.ToString());
				return false;

			}

		}

		private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			try
			{
				int width=e.PageBounds.Width;
				int height=e.PageBounds.Height;

				if(this.isAutoPageRowCount)
					pageRowCount=(int)((height-this.topMargin-titleSize-this.headerFont.Height-this.headerHeight-this.buttomMargin)/this.rowGap);

				pageCount=(int)(rowCount/pageRowCount);
				if(rowCount%pageRowCount>0)
					pageCount++;

				int xoffset=(int)((width-e.Graphics.MeasureString(this.title,this.titleFont).Width)/2);
				int colCount = 0;
				int x = 0;
				int y =topMargin;
				string cellValue = ""; 

				int startRow=currentPageIndex*pageRowCount;
				int endRow=startRow+this.pageRowCount<rowCount?startRow+pageRowCount:rowCount;
				int currentPageRowCount=endRow-startRow;


				if(this.currentPageIndex==0 || this.isEveryPagePrintTitle)
				{
					e.Graphics.DrawString(this.title,titleFont,brush,xoffset,y);
					y+=titleSize;
					//			}
					//------���Ӵ�ӡ��,ֻ�ӵ���һҳ
					y += rowGap;
					x = leftMargin;
					//			dt=DateTime.Now.Year+DateTime.Now.Month+DateTime.Now.Day;
					//									e.Graphics.DrawString("�������ڣ�"+DateTime.Now.Year+"��"+DateTime.Now.Month+"��"+DateTime.Now.Day+"��",font,brush,x,y);
					e.Graphics.DrawString("����ʱ�䣺"+dtB+"��"+dtE,font,brush,x,y);
					//-----------
				}
				colCount = dataGrid.TableStyles[0].GridColumnStyles.Count;

				y += rowGap+10;
				x = leftMargin;


				DrawLine(new Point(x,y),new Point(x,y+currentPageRowCount*rowGap+this.headerHeight),e.Graphics);//����ߵ�����

				int lastIndex=-1;
				int lastLength=0;
				int indexj=-1;

				for(int j = 0; j < colCount; j++)
				{
					int colWidth=dataGrid.TableStyles[0].GridColumnStyles[j].Width;
					if( colWidth> 0)
					{
						indexj++;
						if(this.header==null || this.header[indexj]=="")
							cellValue = dataGrid.TableStyles[0].GridColumnStyles[j].HeaderText; 
						else
							cellValue=header[indexj];

						if(this.isCustomHeader)
						{
							if(this.upLineHeaderIndex[indexj]!=lastIndex)
							{
      
								if(lastLength>0 && lastIndex>-1)//��ʼ����һ��upline
								{
									string upLineStr=this.uplineHeader[lastIndex];
									int upXOffset=(int)((lastLength-e.Graphics.MeasureString(upLineStr,this.upLineFont).Width)/2);
									if(upXOffset<0)
										upXOffset=0;
									e.Graphics.DrawString(upLineStr,this.upLineFont,brush,x-lastLength+upXOffset,y+(int)(this.cellTopMargin/2));

									DrawLine(new Point(x-lastLength,y+(int)(this.headerHeight/2)),new Point(x,y+(int)(this.headerHeight/2)),e.Graphics);//����
									DrawLine(new Point(x,y),new Point(x,y+(int)(this.headerHeight/2)),e.Graphics);
								}
								lastIndex=this.upLineHeaderIndex[indexj];
								lastLength=colWidth+colGap;
							}
							else
							{
								lastLength+=colWidth+colGap;
							}
						}

						//int currentY=y+cellTopMargin;
     
     
						int Xoffset=10;
						int Yoffset=20;
						int leftWordIndex=cellValue.IndexOf(this.splitChar);
						if(this.upLineHeaderIndex!=null && this.upLineHeaderIndex[indexj]>-1)
						{
      
							if(leftWordIndex>0)
							{
								string leftWord=cellValue.Substring(0,leftWordIndex);
								string rightWord=cellValue.Substring(leftWordIndex+1,cellValue.Length-leftWordIndex-1);
								//�������
								Xoffset=(int)(colWidth+colGap-e.Graphics.MeasureString(rightWord,this.upLineFont).Width);
								Yoffset=(int)(this.headerHeight/2-e.Graphics.MeasureString("a",this.underLineFont).Height);

       
								//Xoffset=6;
								//Yoffset=10;
								e.Graphics.DrawString(rightWord,this.underLineFont,brush,x+Xoffset-4,y+(int)(this.headerHeight/2));
								e.Graphics.DrawString(leftWord,this.underLineFont,brush,x+2,y+(int)(this.headerHeight/2)+(int)(this.cellTopMargin/2)+Yoffset-2);
								DrawLine(new Point(x,y+(int)(this.headerHeight/2)),new Point(x+colWidth+colGap,y+headerHeight),e.Graphics);
								x += colWidth + colGap; 
								DrawLine(new Point(x,y+(int)(this.headerHeight/2)),new Point(x,y+currentPageRowCount*rowGap+this.headerHeight),e.Graphics);
							}
							else
							{

								e.Graphics.DrawString(cellValue, headerFont, brush, x, y+(int)(this.headerHeight/2)+(int)(this.cellTopMargin/2));     
								x += colWidth + colGap; 
								DrawLine(new Point(x,y+(int)(this.headerHeight/2)),new Point(x,y+currentPageRowCount*rowGap+this.headerHeight),e.Graphics);
							}
      
						}
						else
						{
							if(leftWordIndex>0)
							{
								string leftWord=cellValue.Substring(0,leftWordIndex);
								string rightWord=cellValue.Substring(leftWordIndex+1,cellValue.Length-leftWordIndex-1);
								//�������
								Xoffset=(int)(colWidth+colGap-e.Graphics.MeasureString(rightWord,this.upLineFont).Width);
								Yoffset=(int)(this.headerHeight-e.Graphics.MeasureString("a",this.underLineFont).Height);

								e.Graphics.DrawString(rightWord,this.headerFont,brush,x+Xoffset-4,y+2);
								e.Graphics.DrawString(leftWord,this.headerFont,brush,x+2,y+Yoffset-4);
								DrawLine(new Point(x,y),new Point(x+colWidth+colGap,y+headerHeight),e.Graphics);
								x += colWidth + colGap; 
								DrawLine(new Point(x,y),new Point(x,y+currentPageRowCount*rowGap+this.headerHeight),e.Graphics);
							}
							else
							{
								Xoffset=(int)((colWidth+cellLeftMargin-e.Graphics.MeasureString(cellValue,this.upLineFont).Width)/2);
								if(Xoffset<0) Xoffset=0;
								Yoffset=(int)((this.headerHeight+cellTopMargin-e.Graphics.MeasureString(cellValue,this.underLineFont).Height)/2);
								//							
								e.Graphics.DrawString(cellValue, headerFont, brush, x+Xoffset, y+Yoffset);
								//							e.Graphics.DrawString(cellValue, headerFont, brush, x, y+cellTopMargin);      
								x += colWidth + colGap; 
								DrawLine(new Point(x,y),new Point(x,y+currentPageRowCount*rowGap+this.headerHeight),e.Graphics);
							}
       
						}

					}
				} 
				////ѭ�������������һ����upLine
				if(this.isCustomHeader)
				{
        
					if(lastLength>0 && lastIndex>-1)//��ʼ����һ��upline
					{
						string upLineStr=this.uplineHeader[lastIndex];
						int upXOffset=(int)((lastLength-e.Graphics.MeasureString(upLineStr,this.upLineFont).Width)/2);
						if(upXOffset<0)
							upXOffset=0;
						e.Graphics.DrawString(upLineStr,this.upLineFont,brush,x-lastLength+upXOffset,y+(int)(this.cellTopMargin/2));

						DrawLine(new Point(x-lastLength,y+(int)(this.headerHeight/2)),new Point(x,y+(int)(this.headerHeight/2)),e.Graphics);//����
						DrawLine(new Point(x,y),new Point(x,y+(int)(this.headerHeight/2)),e.Graphics);
					} 
    
				}
  
				int rightBound=x;

				DrawLine(new Point(leftMargin,y),new Point(rightBound,y),e.Graphics);         //���������

				//DrawLine(new Point(leftMargin,y+this.headerHeight),new Point(rightBound,y+this.headerHeight),e.Graphics);//�������������

				y+=this.headerHeight;


				//print all rows
				for(int i = startRow; i < endRow; i++)
				{
    
					x = leftMargin;
					for(int j = 0; j < colCount; j++)
					{
						if(dataGrid.TableStyles[0].GridColumnStyles[j].Width > 0)
						{
							cellValue = dataGrid[i,j].ToString(); 
							if(cellValue=="False")
								cellValue=falseStr;
							if(cellValue=="True")
								cellValue=trueStr;
       
							e.Graphics.DrawString(cellValue, font, brush, x+this.cellLeftMargin, y+cellTopMargin);
							x += dataGrid.TableStyles[0].GridColumnStyles[j].Width + colGap;
							y = y + rowGap * (cellValue.Split(new char[] {'\r', '\n'}).Length - 1); 
						}
					} 
					DrawLine(new Point(leftMargin,y),new Point(rightBound,y),e.Graphics);
					y += rowGap;
				}
				DrawLine(new Point(leftMargin,y),new Point(rightBound,y),e.Graphics);

				currentPageIndex++;

				if(this.needPrintPageIndex)
					e.Graphics.DrawString("�� "+pageCount.ToString()+" ҳ,��ǰ�� "+this.currentPageIndex.ToString()+" ҳ",this.footerFont,brush,width-200,(int)(height-this.buttomMargin/2-this.footerFont.Height));

				string s = cellValue;
				string f3 = cellValue;


    
				if(currentPageIndex<pageCount)
				{
					e.HasMorePages=true;     
				}
				else
				{
					e.HasMorePages=false;
					this.currentPageIndex=0;
    
				}
				//iPageNumber+=1;
   
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());

			}


		}
		private void DrawLine(Point sp,Point ep,Graphics gp)
		{

			try
			{
				Pen pen=new Pen(Color.Black);
				gp.DrawLine(pen,sp,ep);
			}
			catch(Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		}

		public PrintDocument GetPrintDocument()
		{
			return printDocument;
		}

 

		public void Print()
		{   
			rowCount=0;

			if(dataGrid.DataSource.GetType().ToString() == "System.Data.DataView")
				//				if(dataGrid.DataSource.GetType().ToString() == "System.Data.DataTable")
			{
				//				rowCount = ((DataTable)dataGrid.DataSource).Rows.Count;
				rowCount = ((DataView)dataGrid.DataSource).Count;
			}
			else if(dataGrid.DataSource.GetType().ToString() == "System.Collections.ArrayList")
			{
				rowCount = ((ArrayList)dataGrid.DataSource).Count;
			}


			try
			{
				pageSetupDialog = new PageSetupDialog();
				pageSetupDialog.Document = printDocument;
				pageSetupDialog.PageSettings.Landscape=true;
//				pageSetupDialog.ShowDialog();

				//---------��ʱ��ӡ
				
				//				printDocument.DefaultPageSettings.Landscape = true;
				//				printDocument.Print();
				//				MessageBox.Show("��ӡ���","�ձ����ӡ");

 

				printPreviewDialog = new PrintPreviewDialog();
				printPreviewDialog.Document = printDocument;
				printPreviewDialog.Height = 600;
				printPreviewDialog.Width = 800;
   
				printPreviewDialog.ShowDialog();
			}
			catch(Exception e)
			{
				throw new Exception("Printer error." + e.Message);
			}

		}
	} 
}

//�÷�ʾ������ʾ����綥ͼ��




