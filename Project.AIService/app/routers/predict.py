import sys
import os
data_path = os.path.join(os.path.dirname(__file__), '..', 'auth')
sys.path.append(data_path)
from fastapi import APIRouter, Depends, status, HTTPException, Response, File, UploadFile, Form
from fastapi.responses import JSONResponse
from predict.deepPredict import MobileNetPredict,ResNet50Predict,VGG16Predict
from predict.loadModel import LoadModel
from auth_bearer import JWTBearer,Role
import data.modelRepository as repository
import data.historyRepository as historyRepository
router = APIRouter(tags=['Predict'])

# @router.get('/test',dependencies=[Depends(JWTBearer(role = Role.Admin))] )
@router.post('/AIPredict/DoctorPredict')
async def DoctorPredict(file: UploadFile = File(...), Note: str = Form(...)):
    try:
        input = MobileNetPredict(file.file)
        model = repository.GetActive()
        print(model.ModelID)
        path = os.path.join(os.getcwd(), model.FileUrl)
        result = LoadModel(path,input)
        historyRepository.Create(Note,result,model.ModelID)
        res = {
            "isSuccess": True,
            "data": result
        }
        return JSONResponse(res)
    except Exception as e:
        raise HTTPException(status_code=500, detail="Internal Server Error")
@router.post('/AIPredict/ExpertPredict')
async def ExpertPredict(file: UploadFile = File(...), Note: str = Form(...),ModelID: str = Form(...)):
    try:
        input = MobileNetPredict(file.file)
        model = repository.GetModelUrl(ModelID)
        path = os.path.join(os.getcwd(), model.FileUrl)
        result = LoadModel(path,input)
        historyRepository.Create(Note,result,model.ModelID)
        res = {
            "isSuccess": True,
            "data": result
        }
        return JSONResponse(res)
    except Exception as e:
        raise HTTPException(status_code=500, detail="Internal Server Error")