using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace ERPProject
{
    public partial class Form5 : Form
    {
        Form frn;
        public Form5()
        {
            InitializeComponent();

            textBox6.Text = DateTime.Now.ToString("yy.MM.dd");//서비스접수 신청날짜
            textBox16.Text = DateTime.Now.ToString("yy.MM.dd");
            textBox26.Text = DateTime.Now.ToString("yy.MM.dd");
            textBox34.Text = DateTime.Now.ToString("yy.MM.dd");
            textBox85.Text = DateTime.Now.ToString("yy.MM.dd");
            textBox115.Text = DateTime.Now.ToString("yy.MM.dd");
            textBox104.Text = DateTime.Now.ToString("yy.MM.dd");
            textBox144.Text = DateTime.Now.ToString("yy.MM.dd");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frn.Visible = true;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel4.BringToFront();
            
            //왼쪽 서비스 접수 버튼
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //서비스접수 등록버튼
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //서비스접수 신청자 텍스트박스
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //서비스 접수 신청날짜 
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            int a = 40;
            string strTemp = textBox7.Text;

            string[] arrTemp = strTemp.Split('\r', '\n');

            if (arrTemp[arrTemp.Length - 1].Length >= a) //전역변수 : 10 , 최대길이 10
            {
                strTemp += Environment.NewLine;
            }

            textBox7.Text = strTemp;
            textBox7.Select(textBox7.Text.Length, 0); //offset 이동
            textBox7.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //서비스접수현황 그리드뷰
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //서비스접수현황 등록버튼
            panel11.Visible= true;
            panel11.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel8.BringToFront();
            //왼쪽 서비스접수현황버튼

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            int a = 20;
            string strTemp = textBox18.Text;

            string[] arrTemp = strTemp.Split('\r', '\n');

            if (arrTemp[arrTemp.Length - 1].Length >= a) //전역변수 : 10 , 최대길이 10
            {
                strTemp += Environment.NewLine;
            }

            textBox18.Text = strTemp;
            textBox18.Select(textBox18.Text.Length, 0); //offset 이동
            textBox18.Focus();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel11.Visible= false;
            //서비스접수현황 팝업 등록버튼
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            //서비스접수현황 팝업신청자
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            //서비스접수현황 팝업 날짜
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            //서비스접수현황 팝업 서비스종류
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            //서비스접수현황 팝업 처리현황
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            //담당자 이름
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //수리신청 그리드뷰
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel14.BringToFront();
            //왼쪽 수리신청버튼
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //수리신청 삭제버튼
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //수리신청 수정버튼
            panel17.BringToFront();
            panel17.Visible = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //수리신청 완료버튼
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //수리신청 팝업 그리드뷰
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            panel17.Visible= false;
            //수리신청 팝업 등록
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            //수리신청 팝업 주소 텍스트
        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            //수리신청 검색 텍스트
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //수리신청 검색 텍스트 확인버튼

        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            //서비스접수현황 검색 텍스트박스
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //서비스접수현황 검색 완료 버튼
        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            //대여 현황 검색 텍스트박스
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //대여 현황 검색 완료
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //대여 현황 그리드뷰
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //대여 현황 수정버튼
            panel23.BringToFront();
            panel23.Visible= true;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            //대여 현황 완료버튼
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel20.BringToFront();
            //왼쪽 대여현황 버튼
        }

        private void textBox39_TextChanged(object sender, EventArgs e)
        {
            //대여현황 팝업 대여자
        }

        private void textBox43_TextChanged(object sender, EventArgs e)
        {
            //대여현황 팝업 대여기간
        }

        private void textBox38_TextChanged(object sender, EventArgs e)
        {
            //대여현황 팝업 품목명
        }

        private void textBox42_TextChanged(object sender, EventArgs e)
        {
            //대여현황 팝업 품목기간
        }

        private void textBox47_TextChanged(object sender, EventArgs e)
        {
            //대여현황 팝업 납부정보
        }

        private void textBox51_TextChanged(object sender, EventArgs e)
        {
            //대여현황 팝업 대여비
        }

        private void textBox46_TextChanged(object sender, EventArgs e)
        {
            //대여현황 팝업 대여장소
        }

        private void textBox50_TextChanged(object sender, EventArgs e)
        {
            //대여현황 팝업 담당자
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //대여현황 팝업 완료 
            panel23.Visible = false;
        }

        private void textBox34_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox36_TextChanged(object sender, EventArgs e)
        {
            //대여현황 팝업 맨밑 담당자 이름
        }

        private void textBox55_TextChanged(object sender, EventArgs e)
        {
            //회원관리 검색 텍스트
        }

        private void button27_Click(object sender, EventArgs e)
        {
            //회원관리 완료 버튼
        }

        private void button26_Click(object sender, EventArgs e)
        {
            //회원관리 수정버튼
            panel29.Visible = true;
            panel29.BringToFront();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            //회원관리 완료버튼
        }

        private void textBox65_TextChanged(object sender, EventArgs e)
        {

        }

        private void button29_Click(object sender, EventArgs e)
        {
            panel29.Visible= false;
            //회원관리 팝업 확인
        }

        private void textBox63_TextChanged(object sender, EventArgs e)
        {
            //회원관리 팝업 아이디
        }

        private void textBox61_TextChanged(object sender, EventArgs e)
        {
            //회원관리 팝업 생년월일
        }

        private void textBox62_TextChanged(object sender, EventArgs e)
        {
            //회원관리 팝업 연락처
        }

        private void textBox60_TextChanged(object sender, EventArgs e)
        {
            //회원관리 팝업 이메일
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //회원관리 팝업 그리드뷰
        }

        private void button25_Click(object sender, EventArgs e)
        {
            panel26.BringToFront();
            //왼쪽 회원관리 버튼
        }

        private void button24_Click(object sender, EventArgs e)
        {
            panel32.BringToFront();
            //왼쪽 블랙리스트관리 버튼
        }

        private void textBox58_TextChanged(object sender, EventArgs e)
        {
            //블랙리스트 검색 텍스트
        }

        private void button31_Click(object sender, EventArgs e)
        {
            //블랙리스트 검색 완료버튼
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //블랙리스트 그리드뷰
        }

        private void button32_Click(object sender, EventArgs e)
        {
            //블랙리스트 완료버튼
        }

        private void button30_Click(object sender, EventArgs e)
        {
            //블랙리스트 수정버튼
            panel35.BringToFront();
            panel35.Visible= true;
        }

        private void textBox81_TextChanged(object sender, EventArgs e)
        {
            //블랙리스트 팝업 아이디
        }

        private void textBox77_TextChanged(object sender, EventArgs e)
        {
            //블랙리스트  팝업 생년월일
        }

        private void textBox80_TextChanged(object sender, EventArgs e)
        {
            //블랙리스트 팝업 연락처
        }

        private void textBox76_TextChanged(object sender, EventArgs e)
        {
            //블랙리스트 팝업 이메일
        }

        private void textBox73_TextChanged(object sender, EventArgs e)
        {
            //블랙리스트 팝업 대여품목
        }

        private void textBox72_TextChanged(object sender, EventArgs e)
        {
            //블랙리스트 팝업 품목번호
        }

        private void textBox69_TextChanged(object sender, EventArgs e)
        {
            //블랙리스트 팝업 반납여부
        }

        private void textBox68_TextChanged(object sender, EventArgs e)
        {
            //블랙리스트 팝업 대여날짜
        }

        private void textBox89_TextChanged(object sender, EventArgs e)
        {
            //블랙리스트 팝업 선정날짜
        }

        private void textBox91_TextChanged(object sender, EventArgs e)
        {
            //블랙리스트 팝업 내용
        }

        private void textBox85_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox87_TextChanged(object sender, EventArgs e)
        {
            //블랙리스트 팝업 담당자
        }

        private void button33_Click(object sender, EventArgs e)
        {
            panel35.Visible= false;
            //블랙리스트 팝업 등록 버튼
        }

        private void textBox120_TextChanged(object sender, EventArgs e)
        {
            //미납/연체 검색 텍스트
        }

        private void button36_Click(object sender, EventArgs e)
        {
            //미납/연체 검색텍스트 완료
        }

        private void button35_Click(object sender, EventArgs e)
        {
            //미납/연체 수정버튼
            panel37.Visible= true;
            panel37.BringToFront();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            //미납/연체 완료 버튼
        }

        private void button23_Click(object sender, EventArgs e)
        {
            panel39.BringToFront();
            //미납/연체 왼쪽 버튼
        }

        private void dataGridView9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //미납/연체 팝업 그리드뷰
        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //미납/연체 그리드뷰
        }

        private void textBox111_TextChanged(object sender, EventArgs e)
        {
            //미납/연체 팝업 아이디
        }

        private void textBox107_TextChanged(object sender, EventArgs e)
        {
            //미납/연체 팝업 생년월일
        }

        private void textBox110_TextChanged(object sender, EventArgs e)
        {
            //미납/연체 팝업 연락처
        }

        private void textBox106_TextChanged(object sender, EventArgs e)
        {
            //미납/연체 팝업 이메일
        }

        private void textBox115_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox117_TextChanged(object sender, EventArgs e)
        {
            //미납/연체 팝업 담당자
        }

        private void button34_Click(object sender, EventArgs e)
        {
            //미납/연체 팝업 등록버튼
            panel37.Visible= false;
        }

        private void button39_Click(object sender, EventArgs e)
        {
            //패널안 미납관리 버튼
            panel40.BringToFront();
        }

        private void dataGridView12_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //연체관리 그리드뷰
        }

        private void button40_Click(object sender, EventArgs e)
        {
            panel49.BringToFront();
            //연체관리 버튼
        }

        private void textBox125_TextChanged(object sender, EventArgs e)
        {
            //연체관리 검색 텍스트
        }

        private void button47_Click(object sender, EventArgs e)
        {
            //연체관리 검색 완료
        }

        private void button46_Click(object sender, EventArgs e)
        {
            //연체관리 수정
            panel43.BringToFront();
            panel43.Visible = true;
        }

        private void button48_Click(object sender, EventArgs e)
        {
            //연체관리 완료
        }

        private void textBox100_TextChanged(object sender, EventArgs e)
        {
            //연체관리 팝업 아이디
        }

        private void textBox96_TextChanged(object sender, EventArgs e)
        {
            //연체관리 팝업 생년월일
        }

        private void textBox99_TextChanged(object sender, EventArgs e)
        {
            //연체관리 팝업 연락처
        }

        private void textBox95_TextChanged(object sender, EventArgs e)
        {
            //연체관리 팝업 이메일
        }

        private void dataGridView10_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //연체관리 팝업 그리드뷰
        }

        private void textBox104_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox121_TextChanged(object sender, EventArgs e)
        {
            //연체관리 팝업 담당자이름
        }

        private void button38_Click(object sender, EventArgs e)
        {
            panel43.Visible=false;
            //연체관리 팝업 완료버튼
        }

        private void button22_Click(object sender, EventArgs e)
        {
            panel46.BringToFront();
            //왼쪽 회원탈퇴 버튼
        }

        private void textBox124_TextChanged(object sender, EventArgs e)
        {
            //회원탈퇴관리 검색 텍스트
        }

        private void button44_Click(object sender, EventArgs e)
        {
            //회원탈퇴관리 검색 완료
        }

        private void dataGridView11_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //회원탈퇴관리 그리드뷰
        }

        private void button43_Click(object sender, EventArgs e)
        {
            //회원탈퇴관리 삭제 버튼
            panel51.Visible=true;
            panel51.BringToFront() ;
        }

        private void button45_Click(object sender, EventArgs e)
        {
            //회원탈퇴관리 완료 
        }

        private void button42_Click(object sender, EventArgs e)
        {
            //회원탈퇴관리 팝업 닫기
            panel51.Visible=false;
        }

        private void dataGridView13_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //회원탈퇴관리 팝업 그리드뷰

            
        }

        private void button41_Click(object sender, EventArgs e)
        {
            //회원탈퇴관리 팝업 삭제 버튼
            panel54.Visible=true;
            panel54.BringToFront() ;
        }

        private void textBox144_TextChanged(object sender, EventArgs e)
        {

        }

        private void button50_Click(object sender, EventArgs e)
        {
            //삭제확인 팝업창
            panel54.Visible=false;
        }

        private void button49_Click(object sender, EventArgs e)
        {
            //삭제확인 예 창 이걸로 그리드뷰 삭제해야함
        }



        private void ffff(object obj) // 지정 텍스트 적혀있는 내용 불러옴
        {
            button44.Text= obj.ToString();

            //ffff(this.textBox144); 텍스트 내용을 가져옴
        }
       
    }
}
