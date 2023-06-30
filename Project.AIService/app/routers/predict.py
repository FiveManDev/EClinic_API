import sys
import os
data_path = os.path.join(os.path.dirname(__file__), '..', 'auth')
sys.path.append(data_path)
from fastapi import APIRouter, Depends, status, HTTPException, Response, File, UploadFile, Form
from fastapi.responses import JSONResponse
from predict.deepPredict import MobileNetPredict,ResNet50Predict,VGG16Predict
from predict.loadModel import LoadModel
from auth_bearer import JWTBearer,Role
router = APIRouter(tags=['Predict'])

# @router.get('/test',dependencies=[Depends(JWTBearer(role = Role.Admin))] )
@router.post('/AIPredict/DoctorPredict')
async def DoctorPredict(file: UploadFile = File(...), Note: str = Form(...)):
    try:
        input = MobileNetPredict(file.file)
        path = os.path.join(os.getcwd(), "model/MobileNet_LogisticRegression.pkl")
        result = LoadModel(path,input)
        print(result)
        res = {
            "isSuccess": True,
            "data": Note
        }
        return JSONResponse(res)
    except Exception as e:
        raise HTTPException(status_code=500, detail="Internal Server Error")
@router.post('/AIPredict/ExpertPredict')
async def ExpertPredict(file: UploadFile = File(...), Note: str = Form(...),ModelID: str = Form(...)):
    try:
        # data = repository.GetAll()
        print(file.filename)
        print(ModelID)

        res = {
            "isSuccess": True,
            "data": Note
        }
        return JSONResponse(res)
    except Exception as e:
        raise HTTPException(status_code=500, detail="Internal Server Error")